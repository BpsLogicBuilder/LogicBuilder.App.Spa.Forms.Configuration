using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class FormGroupBoxSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeFormGroupBoxSettingsDescriptor()
        {
            // Arrange
            var descriptor = new FormGroupBoxSettingsDescriptor(
                AbstractControlType.GroupBox,
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
                "Address Information",
                true
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<FormGroupBoxSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.AbstractControlType, deserializedDescriptor.AbstractControlType);
            Assert.NotNull(deserializedDescriptor.FormGroupTemplate);
            Assert.NotNull(deserializedDescriptor.FieldSettings);
            Assert.Single(deserializedDescriptor.FieldSettings);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.ShowTitle, deserializedDescriptor.ShowTitle);
        }
    }
}
