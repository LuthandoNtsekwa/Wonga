using NServiceBus;
using NServiceBus.Logging;
using SharedMedia;
using System;
using System.Threading.Tasks;

namespace Son
{
    class Son
    {
        static async Task Main(string[] args)
        {
            Console.Title = "Son";

            var endpointConfiguration = new EndpointConfiguration(Console.Title);

            var transport = endpointConfiguration.UseTransport<LearningTransport>();

            var routing = transport.Routing();
            routing.RouteToEndpoint(typeof(Message), "Father");

            var endpointInstance = await Endpoint.Start(endpointConfiguration)
                .ConfigureAwait(false);

            await RunLoop(endpointInstance);

            await endpointInstance.Stop()
                .ConfigureAwait(false);
        }

        static ILog log = LogManager.GetLogger<Son>();

        static async Task RunLoop(IEndpointInstance endpointInstance)
        {
            while (true)
            {
                Console.Write("Enter your name or <ENTER> to exit:");
                string name = Console.ReadLine();

                if (!string.IsNullOrEmpty(name))
                {
                    var command = new Message
                    {
                        name = name,
                        msg = "Hello my name is " + name
                    };

                    log.Info(command.msg);
                    await endpointInstance.Send(command)
                        .ConfigureAwait(false);
                }
                else
                    return;
    
            }
        }
    }
}