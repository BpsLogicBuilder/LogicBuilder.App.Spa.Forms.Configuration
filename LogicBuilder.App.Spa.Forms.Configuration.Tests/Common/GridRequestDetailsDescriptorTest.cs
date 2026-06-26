using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class GridRequestDetailsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeGridRequestDetailsDescriptor()
        {
            // Arrange
            var descriptor = new GridRequestDetailsDescriptor(
                "MyNamespace.Person",
                "MyNamespace.PersonData",
                "/api/persons",
                new SelectExpandDefinitionDescriptor(
                    ["Name", "Email"],
                    [
                        new SelectExpandItemDescriptor("Orders")
                    ]
                )
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<GridRequestDetailsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
            Assert.Equal(descriptor.DataType, deserializedDescriptor.DataType);
            Assert.Equal(descriptor.DataSourceUrl, deserializedDescriptor.DataSourceUrl);
            Assert.NotNull(deserializedDescriptor.SelectExpandDefinition);
        }
    }
}
