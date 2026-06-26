using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class FormGroupTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeFormGroupTemplateDescriptor()
        {
            // Arrange
            var descriptor = new FormGroupTemplateDescriptor("GroupTemplate");

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<FormGroupTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.TemplateName, deserializedDescriptor.TemplateName);
        }
    }
}
