using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class ConditionGroupDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeConditionGroupDescriptor()
        {
            // Arrange
            var descriptor = new ConditionGroupDescriptor(
                "and",
                [
                    new ConditionDescriptor("eq", "Status", null, "Active", typeof(string).AssemblyQualifiedName),
                    new ConditionDescriptor("gt", "Age", null, 18, typeof(int).AssemblyQualifiedName)
                ],
                [
                    new ConditionGroupDescriptor(
                        "or",
                        [
                            new ConditionDescriptor("eq", "Type", null, "Premium", typeof(string).AssemblyQualifiedName)
                        ],
                        null
                    )
                ]
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ConditionGroupDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Logic, deserializedDescriptor.Logic);
            Assert.NotNull(deserializedDescriptor.Conditions);
            Assert.Equal(2, deserializedDescriptor.Conditions.Count);
            Assert.NotNull(deserializedDescriptor.ConditionGroups);
            Assert.Single(deserializedDescriptor.ConditionGroups);
        }
    }
}
