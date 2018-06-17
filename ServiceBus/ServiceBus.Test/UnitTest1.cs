using NServiceBus;
using NServiceBus.Testing;
using SharedMedia;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ServiceBus.Test
{
    public class UnitTest1
    {
        [Fact]
        public async Task ShouldReplyWithResponseMessage()
        {
            var handler = new CommunicationHandler();
            var context = new TestableMessageHandlerContext();

            await handler.Handle(new Message {name = "test" }, context)
                .ConfigureAwait(false);

            Assert.Single(context.RepliedMessages);
        }
    }
}
