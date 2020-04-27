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
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace MatchWriter
{
    public class MatchDataConsumer : FanOutConsumer<RedisLocalizationInstruction>
    {
        private readonly IServiceProvider _sp;
        private readonly ILogger<MatchDataConsumer> _logger;
        private readonly IMatchRedis _cache;
        private const string _versionString = "1";

        public MatchDataConsumer(
            IServiceProvider sp,
            IExchangeQueueConnection exchangeQueueConnection,
            ushort prefetchCount = 1) : base(exchangeQueueConnection, prefetchCount)
        {
            _sp = sp;
            _logger = sp.GetRequiredService<ILogger<MatchDataConsumer>>();
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

            using var producer = _sp.GetRequiredService<IProducer<TaskCompletedReport>>();
            try
            {
                // Get matchDataSetJson from redis
                if(model.ExpiryDate <= DateTime.Now)
                {
                    _logger.LogError($"ExpiryDate has already passed. Aborting. Incoming message: {model.ToString()}");

                    producer.PublishMessage(msg);
                    return ConsumedMessageHandling.Done;
                }

                using (var scope = _sp.CreateScope())
                {
                    var _cache = scope.ServiceProvider.GetRequiredService<IMatchRedis>();
                    var matchDataSet = await _cache.GetMatch(model.RedisKey).ConfigureAwait(false);

                    // Upload match to db
                    using var dbHelper = scope.ServiceProvider.GetRequiredService<IDatabaseHelper>();
                    await dbHelper.PutMatchAsync(matchDataSet).ConfigureAwait(false);

                    //Delete uploaded match from redis
                    await _cache.DeleteMatch(model.RedisKey).ConfigureAwait(false);

                    _logger.LogInformation($"Succesfully handled Match#{model.MatchId}.");

                    msg.Success = true;


                    producer.PublishMessage(msg);
                    return ConsumedMessageHandling.Done;
                }
            }
            // If it seems like a temporary failure, resend message
            catch (Exception e) when (e is TimeoutException || e is RedisConnectionException)
            {
                _logger.LogError(e, $"Match#{model.MatchId} could not be uploaded to database right now. Instructing the message to be resent, assuming this is a temporary failure.");

                return ConsumedMessageHandling.Resend;
            }
            // As of now it seems like MatchWriter has a memory leak, which leads to OutOfMemoryException's being thrown for every message. 
            // This catch-block is here to force a restart if this happens. A better solution would be to fix the memory leak.
            catch (Exception e) when (e is OutOfMemoryException)
            {
                _logger.LogError(e, $"Match#{model.MatchId} could not be uploaded to database right now.");
                _logger.LogCritical($"Exiting the application to force a restart with cleared RAM.");
                // Exit with Code 14 (ERROR_OUTOFMEMORY)
                Environment.Exit(14);
                return ConsumedMessageHandling.Resend;
            }

            // When in doubt or the message itself might be corrupt, throw away
            catch (Exception e)
            {
                _logger.LogError(
                    e,
                    "Unhandled Exception - " +
                    $"Match#{model.MatchId} could not stored in the Database, " +
                    "Instructing the message to be thrown away.");

                producer.PublishMessage(msg);
                return ConsumedMessageHandling.ThrowAway;
            }
        }
    }
}
