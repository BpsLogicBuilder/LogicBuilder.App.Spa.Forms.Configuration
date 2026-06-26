using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class VariableDirectivesDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeVariableDirectivesDescriptor()
        {
            // Arrange
            var descriptor = new VariableDirectivesDescriptor(
                "Status",
                [
                    new DirectiveDescriptor(
                        new DirectiveDescriptionDescriptor(
                            "ValidationClass",
                            "ValidateStatus",
                            new Dictionary<string, object>
                            {
                                { "allowedValues", new List<string> { "Active", "Inactive", "Pending" } }
                            }
                        ),
                        new ConditionGroupDescriptor(
                            "and",
                            [
                                new ConditionDescriptor("eq", "IsEnabled", null, true, typeof(bool).AssemblyQualifiedName)
                            ],
                            null
                        )
                    )
                ],
                typeof(string).AssemblyQualifiedName
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<VariableDirectivesDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.NotNull(deserializedDescriptor.ConditionalDirectives);
            Assert.Single(deserializedDescriptor.ConditionalDirectives);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
