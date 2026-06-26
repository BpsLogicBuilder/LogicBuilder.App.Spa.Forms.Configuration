using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class EditFormSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeEditFormSettingsDescriptor()
        {
            // Arrange
            var descriptor = new EditFormSettingsDescriptor(
                "Edit Person",
                "Name",
                new FormRequestDetailsDescriptor(
                    "/api/person/get",
                    "/api/person/add",
                    "/api/person/update",
                    "/api/person/delete",
                    "MyNamespace.Person",
                    "MyNamespace.PersonData",
                    null,
                    null
                ),
                new Dictionary<string, Dictionary<string, string>>
                {
                    {
                        "Name",
                        new Dictionary<string, string>
                        {
                            { "required", "Name is required" }
                        }
                    }
                },
                [
                    new InputFieldControlSettingsDescriptor(
                        AbstractControlType.InputFieldControl,
                        "Name",
                        "nameInput",
                        "Full Name",
                        "Enter name",
                        "text",
                        new TextFieldTemplateDescriptor("TextFieldTemplate"),
                        "MyNamespace.Person",
                        null
                    )
                ],
                new Dictionary<string, List<DirectiveDescriptor>>
                {
                    {
                        "Email",
                        new List<DirectiveDescriptor>
                        {
                            new(
                                new DirectiveDescriptionDescriptor(
                                    "ValidationClass",
                                    "ValidateEmail",
                                    []
                                ),
                                new ConditionGroupDescriptor(
                                    "and",
                                    [
                                        new ConditionDescriptor("eq", "IsEmailRequired", null, true, typeof(bool).AssemblyQualifiedName)
                                    ],
                                    null
                                )
                            )
                        }
                    }
                },
                "MyNamespace.Person"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<EditFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.DisplayField, deserializedDescriptor.DisplayField);
            Assert.NotNull(deserializedDescriptor.RequestDetails);
            Assert.NotNull(deserializedDescriptor.ValidationMessages);
            Assert.NotNull(deserializedDescriptor.FieldSettings);
            Assert.Single(deserializedDescriptor.FieldSettings);
            Assert.NotNull(deserializedDescriptor.ConditionalDirectives);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
