using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class SignalRConnectionDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeSignalRConnectionDescriptor()
        {
            // Arrange
            var descriptor = new SignalRConnectionDescriptor(
                "/agentHub",
                "receiveError",
                "receiveMessage",
                "receiveComplete",
                "sendMessage",
                "sessionInitialized"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SignalRConnectionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.AgentHubUrl, deserializedDescriptor.AgentHubUrl);
            Assert.Equal(descriptor.ReceiveAgentErrorHandler, deserializedDescriptor.ReceiveAgentErrorHandler);
            Assert.Equal(descriptor.ReceiveAgentMessageHandler, deserializedDescriptor.ReceiveAgentMessageHandler);
            Assert.Equal(descriptor.ReceiveAgentResponseCompleteHandler, deserializedDescriptor.ReceiveAgentResponseCompleteHandler);
            Assert.Equal(descriptor.SendMessageToAgentHubMethodName, deserializedDescriptor.SendMessageToAgentHubMethodName);
            Assert.Equal(descriptor.SessionInitializedHandler, deserializedDescriptor.SessionInitializedHandler);
        }
    }
}
