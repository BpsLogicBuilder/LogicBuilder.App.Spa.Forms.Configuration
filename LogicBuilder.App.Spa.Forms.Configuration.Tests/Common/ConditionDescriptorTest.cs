using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class ConditionDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeConditionDescriptor()
        {
            // Arrange
            var descriptor = new ConditionDescriptor(
                "eq",
                "Status",
                null,
                "Active",
                typeof(string).AssemblyQualifiedName
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ConditionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Operator, deserializedDescriptor.Operator);
            Assert.Equal(descriptor.LeftVariable, deserializedDescriptor.LeftVariable);
            Assert.Equal(descriptor.RightVariable, deserializedDescriptor.RightVariable);
            Assert.Equal(descriptor.Value?.ToString(), deserializedDescriptor.Value?.ToString());
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
