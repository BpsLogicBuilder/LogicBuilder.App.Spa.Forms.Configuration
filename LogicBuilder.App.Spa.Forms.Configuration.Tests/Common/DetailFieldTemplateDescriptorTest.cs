using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DetailFieldTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDetailFieldTemplateDescriptor()
        {
            // Arrange
            var descriptor = new DetailFieldTemplateDescriptor("FieldTemplate");

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DetailFieldTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.TemplateName, deserializedDescriptor.TemplateName);
        }
    }
}
