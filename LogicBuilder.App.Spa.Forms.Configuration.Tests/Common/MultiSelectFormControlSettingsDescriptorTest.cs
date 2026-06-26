using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class MultiSelectFormControlSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeMultiSelectFormControlSettingsDescriptor()
        {
            // Arrange
            const string parameterName = "p";
            var descriptor = new MultiSelectFormControlSettingsDescriptor(
                AbstractControlType.MultiSelectFormControl,
                ["Id"],
                "Categories",
                "categoriesMultiSelect",
                "Categories",
                "Select categories",
                "array",
                "MyNamespace.Category",
                new MultiSelectTemplateDescriptor(
                    "MultiSelectTemplate",
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
                    "MyNamespace.Category"
                ),
                null
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<MultiSelectFormControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.AbstractControlType, deserializedDescriptor.AbstractControlType);
            Assert.NotNull(deserializedDescriptor.KeyFields);
            Assert.Single(deserializedDescriptor.KeyFields);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.Equal(descriptor.DomElementId, deserializedDescriptor.DomElementId);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.Placeholder, deserializedDescriptor.Placeholder);
            Assert.Equal(descriptor.Type, deserializedDescriptor.Type);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
            Assert.NotNull(deserializedDescriptor.MultiSelectTemplate);
        }
    }
}
