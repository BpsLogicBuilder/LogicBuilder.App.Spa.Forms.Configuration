using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class MultiSelectTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeMultiSelectTemplateDescriptor()
        {
            // Arrange
            const string parameterName = "p";
            var descriptor = new MultiSelectTemplateDescriptor(
                "MultiSelectTemplate",
                "Select items",
                "Name",
                "Id",
                new SelectorLambdaDescriptor(
                    new MemberSelectorDescriptor("Name", new ParameterDescriptor(parameterName)),
                    typeof(string).AssemblyQualifiedName!,
                    parameterName,
                    typeof(string).AssemblyQualifiedName
                ),
                new RequestDetailsDescriptor(
                    "MyNamespace.Item",
                    "MyNamespace.ItemData",
                    "MyNamespace.Item",
                    "MyNamespace.ItemData",
                    "/api/items",
                    null
                ),
                "MyNamespace.Item"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<MultiSelectTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.TemplateName, deserializedDescriptor.TemplateName);
            Assert.Equal(descriptor.PlaceHolderText, deserializedDescriptor.PlaceHolderText);
            Assert.Equal(descriptor.TextField, deserializedDescriptor.TextField);
            Assert.Equal(descriptor.ValueField, deserializedDescriptor.ValueField);
            Assert.NotNull(deserializedDescriptor.TextAndValueSelector);
            Assert.NotNull(deserializedDescriptor.RequestDetails);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
