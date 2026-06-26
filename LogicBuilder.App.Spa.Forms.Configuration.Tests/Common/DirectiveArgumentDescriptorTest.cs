using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DirectiveArgumentDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDirectiveArgumentDescriptor()
        {
            // Arrange
            var descriptor = new DirectiveArgumentDescriptor(
                "threshold",
                100
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DirectiveArgumentDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Name, deserializedDescriptor.Name);
            Assert.Equal(descriptor.Value.ToString(), deserializedDescriptor.Value.ToString());
        }
    }
}
