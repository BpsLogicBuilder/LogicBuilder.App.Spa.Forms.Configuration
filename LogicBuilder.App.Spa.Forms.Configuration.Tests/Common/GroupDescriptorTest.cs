using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class GroupDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeGroupDescriptor()
        {
            // Arrange
            var descriptor = new GroupDescriptor(
                "Category",
                "asc",
                [
                    new AggregateDefinitionDescriptor("TotalPrice", "sum", typeof(decimal).AssemblyQualifiedName),
                    new AggregateDefinitionDescriptor("Count", "count", null)
                ],
                typeof(string).AssemblyQualifiedName
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<GroupDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.Equal(descriptor.Dir, deserializedDescriptor.Dir);
            Assert.NotNull(deserializedDescriptor.Aggregates);
            Assert.Equal(2, deserializedDescriptor.Aggregates.Count);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
