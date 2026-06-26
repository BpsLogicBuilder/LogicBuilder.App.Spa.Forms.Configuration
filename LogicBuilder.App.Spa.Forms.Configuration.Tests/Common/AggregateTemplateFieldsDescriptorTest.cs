using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class AggregateTemplateFieldsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeAggregateTemplateFieldsDescriptor()
        {
            // Arrange
            var descriptor = new AggregateTemplateFieldsDescriptor(
                "Total Amount",
                "sum"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<AggregateTemplateFieldsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Label, deserializedDescriptor.Label);
            Assert.Equal(descriptor.Function, deserializedDescriptor.Function);
        }
    }
}
