using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class ValidationMessageDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeValidationMessageDescriptor()
        {
            // Arrange
            var descriptor = new ValidationMessageDescriptor(
                "Email",
                new Dictionary<string, string>
                {
                    { "required", "Email is required" },
                    { "email", "Please enter a valid email address" },
                    { "maxLength", "Email cannot exceed 100 characters" }
                },
                typeof(string).AssemblyQualifiedName
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ValidationMessageDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.NotNull(deserializedDescriptor.Methods);
            Assert.Equal(3, deserializedDescriptor.Methods.Count);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
