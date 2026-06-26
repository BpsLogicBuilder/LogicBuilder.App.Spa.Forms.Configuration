using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class RequestDetailsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeRequestDetailsDescriptor()
        {
            // Arrange
            var descriptor = new RequestDetailsDescriptor(
                "MyNamespace.Person",
                "MyNamespace.PersonData",
                "MyNamespace.Person",
                "MyNamespace.PersonData",
                "/api/persons",
                new SelectExpandDefinitionDescriptor(
                    ["Name", "Email", "Age"],
                    [
                        new SelectExpandItemDescriptor("Orders")
                    ]
                )
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<RequestDetailsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
            Assert.Equal(descriptor.DataType, deserializedDescriptor.DataType);
            Assert.Equal(descriptor.ModelReturnType, deserializedDescriptor.ModelReturnType);
            Assert.Equal(descriptor.DataReturnType, deserializedDescriptor.DataReturnType);
            Assert.Equal(descriptor.DataSourceUrl, deserializedDescriptor.DataSourceUrl);
            Assert.NotNull(deserializedDescriptor.SelectExpandDefinition);
        }
    }
}
