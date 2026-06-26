using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class FilterDefinitionDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeFilterDefinitionDescriptor()
        {
            // Arrange
            var descriptor = new FilterDefinitionDescriptor(
                "Name",
                "contains",
                "John",
                true,
                "",
                typeof(string).AssemblyQualifiedName
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<FilterDefinitionDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.Equal(descriptor.Operator, deserializedDescriptor.Operator);
            Assert.Equal(descriptor.Value?.ToString(), deserializedDescriptor.Value?.ToString());
            Assert.Equal(descriptor.IgnoreCase, deserializedDescriptor.IgnoreCase);
            Assert.Equal(descriptor.ValueSourceMember, deserializedDescriptor.ValueSourceMember);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
