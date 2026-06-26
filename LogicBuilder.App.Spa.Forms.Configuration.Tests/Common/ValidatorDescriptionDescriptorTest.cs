using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class ValidatorDescriptionDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeValidatorDescriptionDescriptor()
        {
            // Arrange
            var descriptor = new ValidatorDescriptionDescriptor(
                "ValidatorClass",
                "Required",
                new Dictionary<string, object>
                {
                    { "message", "This field is required" },
                    { "allowEmptyStrings", false }
                }
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ValidatorDescriptionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.ClassName, deserializedDescriptor.ClassName);
            Assert.Equal(descriptor.FunctionName, deserializedDescriptor.FunctionName);
            Assert.NotNull(deserializedDescriptor.Arguments);
            Assert.Equal(2, deserializedDescriptor.Arguments.Count);
        }
    }
}
