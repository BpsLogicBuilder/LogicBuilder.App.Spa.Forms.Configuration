using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class HtmlPageSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeHtmlPageSettingsDescriptor()
        {
            // Arrange
            var descriptor = new HtmlPageSettingsDescriptor(
                new ContentTemplateDescriptor("Welcome", "ContentTemplate"),
                new MessageTemplateDescriptor("Info", "Welcome to our app", "MessageTemplate")
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<HtmlPageSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.NotNull(deserializedDescriptor.ContentTemplate);
            Assert.Equal(descriptor.ContentTemplate!.Title, deserializedDescriptor.ContentTemplate.Title);
            Assert.NotNull(deserializedDescriptor.MessageTemplate);
            Assert.Equal(descriptor.MessageTemplate!.Caption, deserializedDescriptor.MessageTemplate.Caption);
        }
    }
}
