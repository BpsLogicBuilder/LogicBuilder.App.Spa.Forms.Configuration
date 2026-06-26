using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DetailListTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDetailListTemplateDescriptor()
        {
            // Arrange
            var descriptor = new DetailListTemplateDescriptor("ListTemplate");

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DetailListTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.TemplateName, deserializedDescriptor.TemplateName);
        }
    }
}
