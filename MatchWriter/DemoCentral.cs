using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using RabbitCommunicationLib.Enums;
using RabbitCommunicationLib.Interfaces;
using RabbitCommunicationLib.RPC;
using RabbitCommunicationLib.TransferModels;
using RabbitMQ.Client.Events;

namespace MatchWriter
{
    public interface IDemoCentral : IHostedService
    {
        Task<RPCServer<DemoRemovalInstruction, TaskCompletedReport>.ConsumedMessageHandling<TaskCompletedReport>> HandleMessageAndReplyAsync(BasicDeliverEventArgs ea, DemoRemovalInstruction model);
    }

    public class DemoCentral : RPCServer<DemoRemovalInstruction, TaskCompletedReport>, IDemoCentral
    {
        private readonly IDatabaseHelper _databaseHelper;

        public DemoCentral(IRPCQueueConnections queueConnections, IDatabaseHelper databaseHelper, bool persistantMessageSending = true, ushort prefetchCount = 1) : base(queueConnections, persistantMessageSending, prefetchCount)
        {
            _databaseHelper = databaseHelper;
        }

        public async override Task<ConsumedMessageHandling<TaskCompletedReport>> HandleMessageAndReplyAsync(BasicDeliverEventArgs ea, DemoRemovalInstruction model)
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
    }
}
