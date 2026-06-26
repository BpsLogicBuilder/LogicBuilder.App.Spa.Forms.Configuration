using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DropdownSelectorControlSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDropdownSelectorControlSettingsDescriptor()
        {
            // Arrange
            const string parameterName = "p";
            var descriptor = new DropdownSelectorControlSettingsDescriptor(
                AbstractControlType.DropdownSelectorControl,
                "Category",
                "categoryDropdown",
                "Category",
                "Select a category",
                "string",
                new DropDownTemplateDescriptor(
                    "DropDownTemplate",
                    "Select",
                    "Name",
                    "Id",
                    new SelectorLambdaDescriptor(
                        new MemberSelectorDescriptor("Name", new ParameterDescriptor(parameterName)),
                        typeof(string).AssemblyQualifiedName!,
                        parameterName,
                        typeof(string).AssemblyQualifiedName
                    ),
                    new RequestDetailsDescriptor(
                        "MyNamespace.Category",
                        "MyNamespace.CategoryData",
                        "MyNamespace.Category",
                        "MyNamespace.CategoryData",
                        "/api/categories",
                        null
                    ),
                    null,
                    "MyNamespace.Category"
                ),
                "MyNamespace.Category",
                null
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DropdownSelectorControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.AbstractControlType, deserializedDescriptor.AbstractControlType);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.Equal(descriptor.DomElementId, deserializedDescriptor.DomElementId);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.Placeholder, deserializedDescriptor.Placeholder);
            Assert.Equal(descriptor.Type, deserializedDescriptor.Type);
            Assert.NotNull(deserializedDescriptor.DropDownTemplate);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
