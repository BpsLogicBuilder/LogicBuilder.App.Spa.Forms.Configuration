using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class SelectDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeSelectDescriptor()
        {
            // Arrange
            var descriptor = new SelectDescriptor(
                "Name",
                "FullName",
                typeof(string).AssemblyQualifiedName
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<SelectDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.FieldName, deserializedDescriptor.FieldName);
            Assert.Equal(descriptor.SourceMember, deserializedDescriptor.SourceMember);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
