using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class CellListTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeCellListTemplateDescriptor()
        {
            // Arrange
            var descriptor = new CellListTemplateDescriptor(
                "CellListTemplate",
                "Name",
                "MyNamespace.Person"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<CellListTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.TemplateName, deserializedDescriptor.TemplateName);
            Assert.Equal(descriptor.DisplayMember, deserializedDescriptor.DisplayMember);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
