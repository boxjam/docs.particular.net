using System.Fabric;
using System.Threading.Tasks;
using Messages;
using NServiceBus;

namespace ZipCodeVoteCount
{
    public class ReportHandler : IHandleMessages<ReportZipCode>
    {
        public StatefulServiceContext ServiceContext { get; set; }

        public Task Handle(ReportZipCode message, IMessageHandlerContext context)
        {
            ServiceEventSource.Current.ServiceMessage(ServiceContext, $"Closing voting, {message.ZipCode} voted {message.NumberOfVotes} times ");

            return Task.FromResult(true);
        }
    }
}