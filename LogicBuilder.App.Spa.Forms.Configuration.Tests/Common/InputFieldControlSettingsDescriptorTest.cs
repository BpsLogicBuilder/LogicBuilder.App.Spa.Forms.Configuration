using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class InputFieldControlSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeInputFieldControlSettingsDescriptor()
        {
            // Arrange
            var descriptor = new InputFieldControlSettingsDescriptor(
                AbstractControlType.InputFieldControl,
                "Name",
                "nameInput",
                "Full Name",
                "Enter your name",
                "text",
                new TextFieldTemplateDescriptor("TextFieldTemplate"),
                "MyNamespace.Person",
                null
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<InputFieldControlSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.AbstractControlType, deserializedDescriptor.AbstractControlType);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.Equal(descriptor.DomElementId, deserializedDescriptor.DomElementId);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.Placeholder, deserializedDescriptor.Placeholder);
            Assert.Equal(descriptor.Type, deserializedDescriptor.Type);
            Assert.NotNull(deserializedDescriptor.TextTemplate);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
