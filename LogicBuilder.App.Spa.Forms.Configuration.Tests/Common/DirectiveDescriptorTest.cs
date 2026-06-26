using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DirectiveDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDirectiveDescriptor()
        {
            // Arrange
            var descriptor = new DirectiveDescriptor(
                new DirectiveDescriptionDescriptor(
                    "ValidationClass",
                    "ValidateRange",
                    new Dictionary<string, object>
                    {
                        { "min", 0 },
                        { "max", 100 }
                    }
                ),
                new ConditionGroupDescriptor(
                    "and",
                    [
                        new ConditionDescriptor("eq", "IsEnabled", null, true, typeof(bool).AssemblyQualifiedName)
                    ],
                    null
                )
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DirectiveDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.NotNull(deserializedDescriptor.DirectiveDescription);
            Assert.NotNull(deserializedDescriptor.ConditionGroup);
            Assert.Equal(descriptor.DirectiveDescription.ClassName, deserializedDescriptor.DirectiveDescription.ClassName);
            Assert.Equal(descriptor.ConditionGroup.Logic, deserializedDescriptor.ConditionGroup.Logic);
        }
    }
}
