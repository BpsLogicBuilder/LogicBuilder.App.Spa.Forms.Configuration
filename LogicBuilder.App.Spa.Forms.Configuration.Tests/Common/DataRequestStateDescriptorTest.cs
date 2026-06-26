using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DataRequestStateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDataRequestStateDescriptor()
        {
            // Arrange
            var descriptor = new DataRequestStateDescriptor(
                0,
                10,
                [
                    new SortDescriptor("Name", "asc", typeof(string).AssemblyQualifiedName)
                ],
                [
                    new GroupDescriptor(
                        "Category",
                        "asc",
                        [
                            new AggregateDefinitionDescriptor("Price", "sum", typeof(decimal).AssemblyQualifiedName)
                        ],
                        typeof(string).AssemblyQualifiedName
                    )
                ],
                new FilterGroupDescriptor(
                    "and",
                    [
                        new FilterDefinitionDescriptor("Status", "eq", "Active", false, "", typeof(string).AssemblyQualifiedName)
                    ],
                    null
                ),
                [
                    new AggregateDefinitionDescriptor("TotalPrice", "sum", typeof(decimal).AssemblyQualifiedName)
                ]
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DataRequestStateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Skip, deserializedDescriptor.Skip);
            Assert.Equal(descriptor.Take, deserializedDescriptor.Take);
            Assert.NotNull(deserializedDescriptor.Sort);
            Assert.Single(deserializedDescriptor.Sort);
            Assert.NotNull(deserializedDescriptor.Group);
            Assert.Single(deserializedDescriptor.Group);
            Assert.NotNull(deserializedDescriptor.FilterGroup);
            Assert.NotNull(deserializedDescriptor.Aggregates);
            Assert.Single(deserializedDescriptor.Aggregates);
        }
    }
}
