using NServiceBus;
using NServiceBus.Logging;
using SharedMedia;
using System;
using System.Threading.Tasks;

namespace ServiceBus
{
    class Father
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Father";

            var endpointConfiguration = new EndpointConfiguration(Console.Title);
            endpointConfiguration.UseTransport<LearningTransport>();
            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            Console.WriteLine("Waiting for message.");
            Console.ReadLine();

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }
    }

    public class CommunicationHandler : IHandleMessages<Message>
    {
        static ILog log = LogManager.GetLogger<Father>();
        public Task Handle(Message message, IMessageHandlerContext context)
        {
            string reply = $"Hi {message.name}, I am your father.";
            log.Info(reply);
            context.Reply(reply);
            return Task.CompletedTask;
        }
    }
}
