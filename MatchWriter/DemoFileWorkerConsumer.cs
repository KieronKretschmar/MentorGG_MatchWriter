using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitTransfer.Consumer;
using RabbitTransfer.Interfaces;
using RabbitTransfer.TransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatchWriter
{
    public class DemoFileWorkerConsumer : Consumer<TaskCompletedTransferModel>
    {
        private readonly IDatabaseHelper _dbHelper;
        private readonly ILogger<DemoFileWorkerConsumer> _logger;
        private readonly IProducer<TaskCompletedTransferModel> _producer;

        private const string _versionString = "1";

        public DemoFileWorkerConsumer(IQueueConnection queueConnection, ILogger<DemoFileWorkerConsumer> logger, IDatabaseHelper dbHelper, IProducer<TaskCompletedTransferModel> producer) : base(queueConnection)
        {
            _dbHelper = dbHelper;
            _logger = logger;
            _producer = producer;
        }

        public override async Task HandleMessageAsync(IBasicProperties properties, TaskCompletedTransferModel model)
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
                throw new NotImplementedException();
                var matchDataSetJson = "";

                // Upload match to db
                await _dbHelper.PutMatchAsync(matchDataSetJson).ConfigureAwait(false);

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
