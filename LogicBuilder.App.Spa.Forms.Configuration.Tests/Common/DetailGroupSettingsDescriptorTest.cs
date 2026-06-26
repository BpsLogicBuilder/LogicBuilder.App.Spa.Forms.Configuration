using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DetailGroupSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDetailGroupSettingsDescriptor()
        {
            // Arrange
            const string parameterName = "p";
            var descriptor = new DetailGroupSettingsDescriptor(
                DetailItemType.Group,
                "Address",
                "Address Information",
                new DetailGroupTemplateDescriptor("GroupTemplate"),
                [
                    new DetailFieldSettingDescriptor(
                        DetailItemType.Field,
                        "Street",
                        "Street",
                        "string",
                        "MyNamespace.Address",
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
                                "MyNamespace.Address",
                                "MyNamespace.AddressData",
                                "MyNamespace.Address",
                                "MyNamespace.AddressData",
                                "/api/addresses",
                                null
                            ),
                            null,
                            "MyNamespace.Address"
                        )
                    )
                ],
                "MyNamespace.Address"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DetailGroupSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.DetailType, deserializedDescriptor.DetailType);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.NotNull(deserializedDescriptor.GroupTemplate);
            Assert.NotNull(deserializedDescriptor.FieldSettings);
            Assert.Single(deserializedDescriptor.FieldSettings);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
