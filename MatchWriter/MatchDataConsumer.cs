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
    public class MatchDataConsumer : Consumer<MatchDatabaseInsertionInstruction>
    {
        private readonly IServiceProvider _sp;
        private readonly ILogger<MatchDataConsumer> _logger;
        private readonly IMatchRedis _cache;

        public MatchDataConsumer(
            IServiceProvider sp,
            IExchangeQueueConnection exchangeQueueConnection,
            ushort prefetchCount = 1) : base(exchangeQueueConnection, prefetchCount)
        {
            _sp = sp;
            _logger = sp.GetRequiredService<ILogger<MatchDataConsumer>>();
        }

        public override async Task<ConsumedMessageHandling> HandleMessageAsync(BasicDeliverEventArgs ea, MatchDatabaseInsertionInstruction model)
        {
            _logger.LogInformation($"Received message for Match#{model.MatchId}: [ {model.ToJson()} ]");

            // Initialize TaskCompleted message
            var msg = new MatchDatabaseInsertionReport(model.MatchId);

            using var producer = _sp.GetRequiredService<IProducer<TaskCompletedReport>>();
            try
            {
                // Get matchDataSetJson from redis
                if(model.ExpiryDate <= DateTime.Now)
                {
                    _logger.LogError($"MatchId [ {model.MatchId} ] ExpiryDate has passed. Aborting");

                    msg.Block = DemoAnalysisBlock.MatchWriter_MatchDataSetUnavailable;
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

                    _logger.LogInformation($"Successfully handled MatchId [ {model.MatchId} ]");

                    msg.Success = true;

                    producer.PublishMessage(msg);
                    return ConsumedMessageHandling.Done;
                }
            }

            // If a match was expected in Redis but not found
            catch (Exception e) when (e is MatchEmptyOrNull)
            {
                _logger.LogError(
                    e,
                    $"MatchId [ {model.MatchId} ] Could not retreive Match from Redis.");

                await _cache.DeleteMatch(model.RedisKey).ConfigureAwait(false);

                msg.Block = DemoAnalysisBlock.MatchWriter_MatchDataSetUnavailable;
                producer.PublishMessage(msg);
                return ConsumedMessageHandling.Done;
            }

            catch (RedisConnectionException e)
            {
                _logger.LogError(e, $"MatchId [ {model.MatchId} ] could not be uploaded to database right now due to a RedisConnectionException.");

                msg.Block = DemoAnalysisBlock.MatchWriter_RedisConnectionFailed;
                producer.PublishMessage(msg);
                return ConsumedMessageHandling.Done;
            }

            catch (TimeoutException e)
            {
                _logger.LogError(e, $"MatchId [ {model.MatchId} ] could not be uploaded to database right now due to a TimeoutException.");

                msg.Block = DemoAnalysisBlock.MatchWriter_Timeout;
                producer.PublishMessage(msg);
                return ConsumedMessageHandling.Done;
            }

            catch (Microsoft.EntityFrameworkCore.DbUpdateException e)
            {
                _logger.LogError(e, $"MatchId [ {model.MatchId} ] could not be uploaded to database right now due to a Microsoft.EntityFrameworkCore.DbUpdateException.");

                msg.Block = DemoAnalysisBlock.MatchWriter_DatabaseUpload;
                producer.PublishMessage(msg);
                return ConsumedMessageHandling.Done;
            }

            // As of now it seems like MatchWriter has a memory leak, which, at a critical point, leads to OutOfMemoryExceptions being thrown for every message. 
            // This catch-block is here to force a restart if this happens. A better solution would be to fix the memory leak.
            catch (OutOfMemoryException e)
            {
                _logger.LogError(e, $"MatchId [ {model.MatchId} ] could not be uploaded to database right now.");
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
                    $"MatchId [ {model.MatchId} ] could not stored in the Database, " +
                    "Instructing the message to be thrown away.");

                msg.Block = DemoAnalysisBlock.MatchWriter_Unknown;
                producer.PublishMessage(msg);
                return ConsumedMessageHandling.Done;
            }
        }
    }
}
