using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class FormRequestDetailsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeFormRequestDetailsDescriptor()
        {
            // Arrange
            const string parameterName = "p";
            var descriptor = new FormRequestDetailsDescriptor(
                "/api/person/get",
                "/api/person/add",
                "/api/person/update",
                "/api/person/delete",
                "MyNamespace.Person",
                "MyNamespace.PersonData",
                new FilterLambdaDescriptor(
                    new GreaterThanBinaryDescriptor(
                        new MemberSelectorDescriptor("Age", new ParameterDescriptor(parameterName)),
                        new ConstantDescriptor(18, typeof(int).AssemblyQualifiedName)
                    ),
                    "MyNamespace.Person",
                    parameterName
                ),
                new SelectExpandDefinitionDescriptor(
                    ["Name", "Email", "Age"],
                    [
                        new SelectExpandItemDescriptor("Orders")
                    ]
                )
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<FormRequestDetailsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.GetUrl, deserializedDescriptor.GetUrl);
            Assert.Equal(descriptor.AddUrl, deserializedDescriptor.AddUrl);
            Assert.Equal(descriptor.UpdateUrl, deserializedDescriptor.UpdateUrl);
            Assert.Equal(descriptor.DeleteUrl, deserializedDescriptor.DeleteUrl);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
            Assert.Equal(descriptor.DataType, deserializedDescriptor.DataType);
            Assert.NotNull(deserializedDescriptor.Filter);
            Assert.NotNull(deserializedDescriptor.SelectExpandDefinition);
        }
    }
}
