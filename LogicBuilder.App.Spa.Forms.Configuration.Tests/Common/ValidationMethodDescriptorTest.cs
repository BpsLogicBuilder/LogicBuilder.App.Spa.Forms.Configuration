using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class ValidationMethodDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeValidationMethodDescriptor()
        {
            // Arrange
            var descriptor = new ValidationMethodDescriptor(
                "required",
                "This field is required"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ValidationMethodDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Method, deserializedDescriptor.Method);
            Assert.Equal(descriptor.Message, deserializedDescriptor.Message);
        }
    }
}
