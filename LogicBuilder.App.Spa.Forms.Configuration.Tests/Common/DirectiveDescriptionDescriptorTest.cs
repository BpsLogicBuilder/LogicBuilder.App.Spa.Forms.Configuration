using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DirectiveDescriptionDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDirectiveDescriptionDescriptor()
        {
            // Arrange
            var descriptor = new DirectiveDescriptionDescriptor(
                "ValidationClass",
                "ValidateRange",
                new Dictionary<string, object>
                {
                    { "min", 0 },
                    { "max", 100 },
                    { "errorMessage", "Value must be between 0 and 100" }
                }
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DirectiveDescriptionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.ClassName, deserializedDescriptor.ClassName);
            Assert.Equal(descriptor.FunctionName, deserializedDescriptor.FunctionName);
            Assert.NotNull(deserializedDescriptor.Arguments);
            Assert.Equal(3, deserializedDescriptor.Arguments.Count);
        }
    }
}
