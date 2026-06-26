using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class TextFieldTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeTextFieldTemplateDescriptor()
        {
            // Arrange
            var descriptor = new TextFieldTemplateDescriptor("TextFieldTemplate");

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<TextFieldTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.TemplateName, deserializedDescriptor.TemplateName);
        }
    }
}
