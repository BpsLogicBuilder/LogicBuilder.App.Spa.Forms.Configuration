using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class CommandColumnDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeCommandColumnDescriptor()
        {
            // Arrange
            var descriptor = new CommandColumnDescriptor(
                "Actions",
                150
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<CommandColumnDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.Width, deserializedDescriptor.Width);
        }
    }
}
