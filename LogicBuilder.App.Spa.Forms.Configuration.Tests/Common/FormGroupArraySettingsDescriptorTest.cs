using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class FormGroupArraySettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeFormGroupArraySettingsDescriptor()
        {
            // Arrange
            var descriptor = new FormGroupArraySettingsDescriptor(
                AbstractControlType.FormGroupArray,
                "Orders",
                new FormGroupTemplateDescriptor("GroupTemplate"),
                [
                    new InputFieldControlSettingsDescriptor(
                        AbstractControlType.InputFieldControl,
                        "OrderId",
                        "orderIdInput",
                        "Order ID",
                        "Enter order ID",
                        "number",
                        new TextFieldTemplateDescriptor("TextFieldTemplate"),
                        "MyNamespace.Order",
                        null
                    )
                ],
                new Dictionary<string, Dictionary<string, string>>
                {
                    {
                        "OrderId",
                        new Dictionary<string, string>
                        {
                            { "required", "Order ID is required" }
                        }
                    }
                },
                ["OrderId"],
                [],
                "Orders",
                true,
                "MyNamespace.Order"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<FormGroupArraySettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.AbstractControlType, deserializedDescriptor.AbstractControlType);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.NotNull(deserializedDescriptor.FormGroupTemplate);
            Assert.NotNull(deserializedDescriptor.FieldSettings);
            Assert.Single(deserializedDescriptor.FieldSettings);
            Assert.NotNull(deserializedDescriptor.ValidationMessages);
            Assert.NotNull(deserializedDescriptor.KeyFields);
            Assert.Single(deserializedDescriptor.KeyFields);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.ShowTitle, deserializedDescriptor.ShowTitle);
            Assert.Equal(descriptor.ArrayElementType, deserializedDescriptor.ArrayElementType);
        }
    }
}
