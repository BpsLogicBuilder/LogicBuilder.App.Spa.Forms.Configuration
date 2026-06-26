using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class ContentTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeContentTemplateDescriptor()
        {
            // Arrange
            var descriptor = new ContentTemplateDescriptor(
                "Welcome Page",
                "ContentTemplate"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ContentTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.TemplateName, deserializedDescriptor.TemplateName);
        }
    }
}
