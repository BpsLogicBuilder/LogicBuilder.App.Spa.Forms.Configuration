using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class FilterGroupDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeFilterGroupDescriptor()
        {
            // Arrange
            var descriptor = new FilterGroupDescriptor(
                "and",
                [
                    new FilterDefinitionDescriptor("Name", "contains", "John", true, "", typeof(string).AssemblyQualifiedName),
                    new FilterDefinitionDescriptor("Age", "gte", 18, null, "", typeof(int).AssemblyQualifiedName)
                ],
                [
                    new FilterGroupDescriptor(
                        "or",
                        [
                            new FilterDefinitionDescriptor("Status", "eq", "Active", false, "", typeof(string).AssemblyQualifiedName)
                        ],
                        null
                    )
                ]
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<FilterGroupDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Logic, deserializedDescriptor.Logic);
            Assert.NotNull(deserializedDescriptor.Filters);
            Assert.Equal(2, deserializedDescriptor.Filters.Count);
            Assert.NotNull(deserializedDescriptor.FilterGroups);
            Assert.Single(deserializedDescriptor.FilterGroups);
        }
    }
}
