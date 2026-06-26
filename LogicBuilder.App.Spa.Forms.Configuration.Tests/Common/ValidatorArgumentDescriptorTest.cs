using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class ValidatorArgumentDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeValidatorArgumentDescriptor()
        {
            // Arrange
            var descriptor = new ValidatorArgumentDescriptor(
                "maxLength",
                100
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ValidatorArgumentDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Name, deserializedDescriptor.Name);
            Assert.Equal(descriptor.Value.ToString(), deserializedDescriptor.Value.ToString());
        }
    }
}
