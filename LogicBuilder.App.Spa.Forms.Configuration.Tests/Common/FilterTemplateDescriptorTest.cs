using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class FilterTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeFilterTemplateDescriptor()
        {
            // Arrange
            const string parameterName = "p";
            var descriptor = new FilterTemplateDescriptor(
                "FilterTemplate",
                false,
                "Name",
                "Id",
                new SelectorLambdaDescriptor(
                    new MemberSelectorDescriptor("Name", new ParameterDescriptor(parameterName)),
                    typeof(string).AssemblyQualifiedName!,
                    parameterName,
                    typeof(string).AssemblyQualifiedName
                ),
                new RequestDetailsDescriptor(
                    "MyNamespace.Person",
                    "MyNamespace.PersonData",
                    "MyNamespace.Person",
                    "MyNamespace.PersonData",
                    "/api/persons",
                    null
                ),
                "MyNamespace.Person"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<FilterTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.TemplateName, deserializedDescriptor.TemplateName);
            Assert.Equal(descriptor.IsPrimitive, deserializedDescriptor.IsPrimitive);
            Assert.Equal(descriptor.TextField, deserializedDescriptor.TextField);
            Assert.Equal(descriptor.ValueField, deserializedDescriptor.ValueField);
            Assert.NotNull(deserializedDescriptor.TextAndValueSelector);
            Assert.NotNull(deserializedDescriptor.RequestDetails);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
