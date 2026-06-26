using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DetailFormSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDetailFormSettingsDescriptor()
        {
            // Arrange
            const string parameterName = "p";
            var descriptor = new DetailFormSettingsDescriptor(
                "Person Details",
                "Name",
                new FormRequestDetailsDescriptor(
                    "/api/person/get",
                    "/api/person/add",
                    "/api/person/update",
                    "/api/person/delete",
                    "MyNamespace.Person",
                    "MyNamespace.PersonData",
                    new FilterLambdaDescriptor(
                        new GreaterThanBinaryDescriptor(
                            new MemberSelectorDescriptor("Age", new ParameterDescriptor(parameterName)),
                            new ConstantDescriptor(18, typeof(int).AssemblyQualifiedName)
                        ),
                        "MyNamespace.Person",
                        parameterName
                    ),
                    new SelectExpandDefinitionDescriptor(
                        ["Name", "Email"],
                        null
                    )
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
                ],
                "MyNamespace.Person"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DetailFormSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.DisplayField, deserializedDescriptor.DisplayField);
            Assert.NotNull(deserializedDescriptor.RequestDetails);
            Assert.NotNull(deserializedDescriptor.FieldSettings);
            Assert.Single(deserializedDescriptor.FieldSettings);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
