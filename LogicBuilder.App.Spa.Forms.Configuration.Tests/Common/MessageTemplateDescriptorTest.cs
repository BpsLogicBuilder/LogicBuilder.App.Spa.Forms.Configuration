using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class MessageTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeMessageTemplateDescriptor()
        {
            // Arrange
            var descriptor = new MessageTemplateDescriptor(
                "Welcome",
                "Welcome to our application!",
                "MessageTemplate"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<MessageTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Caption, deserializedDescriptor.Caption);
            Assert.Equal(descriptor.Message, deserializedDescriptor.Message);
            Assert.Equal(descriptor.TemplateName, deserializedDescriptor.TemplateName);
        }
    }
}
