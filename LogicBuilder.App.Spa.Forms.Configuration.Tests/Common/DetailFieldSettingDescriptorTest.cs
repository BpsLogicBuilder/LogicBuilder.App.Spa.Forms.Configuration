using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DetailFieldSettingDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDetailFieldSettingDescriptor()
        {
            // Arrange
            const string parameterName = "p";
            var descriptor = new DetailFieldSettingDescriptor(
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
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DetailFieldSettingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.DetailType, deserializedDescriptor.DetailType);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.Type, deserializedDescriptor.Type);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
            Assert.NotNull(deserializedDescriptor.FieldTemplate);
            Assert.NotNull(deserializedDescriptor.ValueTextTemplate);
        }
    }
}
