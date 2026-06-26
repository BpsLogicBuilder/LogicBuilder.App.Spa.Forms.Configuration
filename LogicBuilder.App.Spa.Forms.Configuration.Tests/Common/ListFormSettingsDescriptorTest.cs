using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class ListFormSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeListFormSettingsDescriptor()
        {
            // Arrange
            const string parameterName = "p";
            var descriptor = new ListFormSettingsDescriptor(
                "Person List",
                new RequestDetailsDescriptor(
                    "MyNamespace.Person",
                    "MyNamespace.PersonData",
                    "MyNamespace.Person",
                    "MyNamespace.PersonData",
                    "/api/persons",
                    new SelectExpandDefinitionDescriptor(
                        ["Name", "Email"],
                        null
                    )
                ),
                new SelectorLambdaDescriptor(
                    new MemberSelectorDescriptor("Name", new ParameterDescriptor(parameterName)),
                    typeof(string).AssemblyQualifiedName!,
                    parameterName,
                    typeof(string).AssemblyQualifiedName
                ),
                [
                    new DetailFieldSettingDescriptor(
                        DetailItemType.Field,
                        "Name",
                        "Full Name",
                        "string",
                        "MyNamespace.Person",
                        new DetailFieldTemplateDescriptor("FieldTemplate"),
                        new DetailDropDownTemplateDescriptor(
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
                                "MyNamespace.Person",
                                "MyNamespace.PersonData",
                                "MyNamespace.Person",
                                "MyNamespace.PersonData",
                                "/api/persons",
                                null
                            ),
                            null,
                            "MyNamespace.Person"
                        )
                    )
                ]
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ListFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.NotNull(deserializedDescriptor.RequestDetails);
            Assert.NotNull(deserializedDescriptor.FieldsSelector);
            Assert.NotNull(deserializedDescriptor.FieldSettings);
            Assert.Single(deserializedDescriptor.FieldSettings);
        }
    }
}
