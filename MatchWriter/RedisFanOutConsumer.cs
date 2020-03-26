using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitCommunicationLib.Consumer;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.TransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitCommunicationLib.Enums;
using RabbitMQ.Client.Events;

namespace MatchWriter
{
    public class MatchFanOutConsumer : FanOutConsumer<RedisLocalizationInstruction>
    {
        private readonly IDatabaseHelper _dbHelper;
        private readonly ILogger<MatchFanOutConsumer> _logger;
        private readonly IProducer<TaskCompletedReport> _producer;
        private readonly IMatchRedis _cache;
        private const string _versionString = "1";

        public MatchFanOutConsumer(
            IExchangeQueueConnection exchangeQueueConnection, 
            ILogger<MatchFanOutConsumer> logger, 
            IDatabaseHelper dbHelper, 
            IProducer<TaskCompletedReport> producer, 
            IMatchRedis cache, 
            ushort prefetchCount = 1) : base(exchangeQueueConnection, prefetchCount)
        {
            _dbHelper = dbHelper;
            _logger = logger;
            _producer = producer;
            _cache = cache;
        }

        public override async Task<ConsumedMessageHandling> HandleMessageAsync(BasicDeliverEventArgs ea, RedisLocalizationInstruction model)
        {
            _logger.LogInformation($"Received message for Match#{model.MatchId}: [ {model.ToJson()} ]");

            // Initialize TaskCompleted message
            var msg = new TaskCompletedReport
            {
                Version = _versionString, 
                Success = false,
                MatchId = model.MatchId,
            };

            try
            {
                // Get matchDataSetJson from redis
                if(model.ExpiryDate <= DateTime.Now)
                {
                    _logger.LogError($"ExpiryDate has already passed. Aborting. Incoming message: {model.ToString()}");

                    _producer.PublishMessage(msg);
                    return ConsumedMessageHandling.ThrowAway;
                }
                var matchDataSet = await _cache.GetMatch(model.RedisKey).ConfigureAwait(false);

                // Upload match to db
                await _dbHelper.PutMatchAsync(matchDataSet).ConfigureAwait(false);

                _logger.LogInformation($"Succesfully handled Match#{model.MatchId}.");

                msg.Success = true;
                _producer.PublishMessage(msg);
                return ConsumedMessageHandling.Done;
            }
            // If it seems like a temporary failure, resend message
            catch (Exception e) when (e is TimeoutException)
            {
                _logger.LogError(e, $"Match#{model.MatchId} could not be uploaded to database right now. Instructing the message to be resent, assuming this is a temporary failure.");

                _producer.PublishMessage(msg);
                return ConsumedMessageHandling.Resend;
            }
            // When in doubt or the message itself might be corrupt, throw away
            catch (Exception e)
            {
                _logger.LogError(e, $"Match#{model.MatchId} could not be uploaded to database. Instructing the message to be thrown away, assuming the message is corrupt.");

                _producer.PublishMessage(msg);
                return ConsumedMessageHandling.ThrowAway;
            }
        }
    }
}
