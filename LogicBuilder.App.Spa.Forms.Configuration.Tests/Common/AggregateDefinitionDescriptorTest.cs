using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class AggregateDefinitionDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeAggregateDefinitionDescriptor()
        {
            // Arrange
            var descriptor = new AggregateDefinitionDescriptor(
                "TotalPrice",
                "sum",
                typeof(decimal).AssemblyQualifiedName
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<AggregateDefinitionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.Equal(descriptor.Aggregate, deserializedDescriptor.Aggregate);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
