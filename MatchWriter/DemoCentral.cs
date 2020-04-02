using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.RPC;
using RabbitCommunicationLib.TransferModels;
using RabbitMQ.Client.Events;


namespace MatchWriter
{
    /// <summary>
    /// Handle messages from the democentral queue, remove the specified match data.
    /// </summary>
    public interface IDemoCentral : IHostedService
    {
        Task<RPCServer<DemoRemovalInstruction, TaskCompletedReport>.ConsumedMessageHandling<TaskCompletedReport>> HandleMessageAndReplyAsync(BasicDeliverEventArgs ea, DemoRemovalInstruction model);
    }

    public class DemoCentral : RPCServer<DemoRemovalInstruction, TaskCompletedReport>, IDemoCentral
    {
        private readonly IDatabaseHelper _databaseHelper;
        private readonly ILogger<DemoCentral> _logger;

        public DemoCentral(IRPCQueueConnections queueConnections, IDatabaseHelper databaseHelper, ILogger<DemoCentral> logger, bool persistantMessageSending = true, ushort prefetchCount = 1) : base(queueConnections, persistantMessageSending, prefetchCount)
        {
            _databaseHelper = databaseHelper;
            _logger = logger;
        }

        public async override Task<ConsumedMessageHandling<TaskCompletedReport>> HandleMessageAndReplyAsync(BasicDeliverEventArgs ea, DemoRemovalInstruction model)
        {
            try
            {
                await _databaseHelper.RemoveMatchAsync(model.MatchId).ConfigureAwait(false);
                var report = new TaskCompletedReport
                {
                    MatchId = model.MatchId,
                    Success = true,
                };


                return new ConsumedMessageHandling<TaskCompletedReport>
                {
                    MessageHandling = ConsumedMessageHandling.Done,
                    TransferModel = report,
                };

            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Failed to remove match [ {model.MatchId } ], throwing away message");
                return new ConsumedMessageHandling<TaskCompletedReport>
                {
                    MessageHandling = ConsumedMessageHandling.ThrowAway
                };
            }
        }
    }
}
