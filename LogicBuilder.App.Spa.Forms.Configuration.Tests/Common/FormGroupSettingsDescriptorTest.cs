using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class FormGroupSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeFormGroupSettingsDescriptor()
        {
            // Arrange
            var descriptor = new FormGroupSettingsDescriptor(
                AbstractControlType.FormGroup,
                "Address",
                new FormGroupTemplateDescriptor("GroupTemplate"),
                [
                    new InputFieldControlSettingsDescriptor(
                        AbstractControlType.InputFieldControl,
                        "Street",
                        "streetInput",
                        "Street",
                        "Enter street",
                        "text",
                        new TextFieldTemplateDescriptor("TextFieldTemplate"),
                        "MyNamespace.Address",
                        null
                    )
                ],
                new Dictionary<string, Dictionary<string, string>>
                {
                    {
                        "Street",
                        new Dictionary<string, string>
                        {
                            { "required", "Street is required" }
                        }
                    }
                },
                [],
                "Address Information",
                true,
                "MyNamespace.Address"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<FormGroupSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.AbstractControlType, deserializedDescriptor.AbstractControlType);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.NotNull(deserializedDescriptor.FormGroupTemplate);
            Assert.NotNull(deserializedDescriptor.FieldSettings);
            Assert.Single(deserializedDescriptor.FieldSettings);
            Assert.NotNull(deserializedDescriptor.ValidationMessages);
            Assert.NotNull(deserializedDescriptor.ConditionalDirectives);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.ShowTitle, deserializedDescriptor.ShowTitle);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
