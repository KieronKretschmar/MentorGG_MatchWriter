using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitCommunicationLib.Consumer;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.TransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchWriter
{
    public class DemoFileWorkerConsumer : Consumer<RedisTaskCompletedTransferModel>
    {
        private readonly IDatabaseHelper _dbHelper;
        private readonly ILogger<DemoFileWorkerConsumer> _logger;
        private readonly IProducer<TaskCompletedTransferModel> _producer;
        private readonly IMatchRedis _cache;
        private const string _versionString = "1";

        public DemoFileWorkerConsumer(IQueueConnection queueConnection, ILogger<DemoFileWorkerConsumer> logger, IDatabaseHelper dbHelper, IProducer<TaskCompletedTransferModel> producer, IMatchRedis cache) : base(queueConnection)
        {
            _dbHelper = dbHelper;
            _logger = logger;
            _producer = producer;
            _cache = cache;
        }

        public override async Task HandleMessageAsync(IBasicProperties properties, RedisTaskCompletedTransferModel model)
        {
            long matchId = long.Parse(properties.CorrelationId);

            // Initialize TaskCompleted message
            var msg = new TaskCompletedTransferModel
            {
                Version = _versionString, 
                Success = false
            };

            try
            {
                // Get matchDataSetJson from redis
                if(model.ExpiryDate >= DateTime.Now)
                {
                    msg.Success = false;
                    throw new Exception($"ExpiryDate has already passed. Aborting. Incoming message: {model.ToString()}");
                }
                var matchDataSet = await _cache.GetMatch(model.RedisKey).ConfigureAwait(false);

                // Upload match to db
                await _dbHelper.PutMatchAsync(matchDataSet).ConfigureAwait(false);

                msg.Success = true;
            }
            catch (Exception e)
            {
                _logger.LogError($"Error uploading Match#{matchId} to database.", e);
                msg.Success = false;
            }
            finally
            {
                _producer.PublishMessage(matchId.ToString(), msg);
            }
        }
    }
}
