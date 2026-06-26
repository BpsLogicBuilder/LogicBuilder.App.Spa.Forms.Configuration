using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DetailGroupTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDetailGroupTemplateDescriptor()
        {
            // Arrange
            var descriptor = new DetailGroupTemplateDescriptor("GroupTemplate");

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DetailGroupTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.TemplateName, deserializedDescriptor.TemplateName);
        }
    }
}
