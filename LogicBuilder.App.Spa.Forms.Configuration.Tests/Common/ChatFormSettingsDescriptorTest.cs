using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class ChatFormSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeChatFormSettingsDescriptor()
        {
            // Arrange
            var descriptor = new ChatFormSettingsDescriptor(
                "Live Chat",
                "agentConfig",
                600,
                400,
                new SignalRConnectionDescriptor(
                    "/agentHub",
                    "receiveError",
                    "receiveMessage",
                    "receiveComplete",
                    "sendMessage",
                    "sessionInitialized"
                )
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ChatFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.AgentConfigurationIdentifier, deserializedDescriptor.AgentConfigurationIdentifier);
            Assert.Equal(descriptor.ChatHeight, deserializedDescriptor.ChatHeight);
            Assert.Equal(descriptor.ChatWidth, deserializedDescriptor.ChatWidth);
            Assert.NotNull(deserializedDescriptor.SignalRConnection);
            Assert.Equal(descriptor.SignalRConnection.AgentHubUrl, deserializedDescriptor.SignalRConnection.AgentHubUrl);
            Assert.Equal(descriptor.SignalRConnection.ReceiveAgentErrorHandler, deserializedDescriptor.SignalRConnection.ReceiveAgentErrorHandler);
            Assert.Equal(descriptor.SignalRConnection.ReceiveAgentMessageHandler, deserializedDescriptor.SignalRConnection.ReceiveAgentMessageHandler);
            Assert.Equal(descriptor.SignalRConnection.ReceiveAgentResponseCompleteHandler, deserializedDescriptor.SignalRConnection.ReceiveAgentResponseCompleteHandler);
            Assert.Equal(descriptor.SignalRConnection.SendMessageToAgentHubMethodName, deserializedDescriptor.SignalRConnection.SendMessageToAgentHubMethodName);
            Assert.Equal(descriptor.SignalRConnection.SessionInitializedHandler, deserializedDescriptor.SignalRConnection.SessionInitializedHandler);
        }
    }
}
