using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class ColumnSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeColumnSettingsDescriptor()
        {
            // Arrange
            const string parameterName = "p";
            var descriptor = new ColumnSettingsDescriptor(
                "Name",
                "Full Name",
                "string",
                true,
                200,
                null,
                "text",
                new CellTemplateDescriptor("CellTemplate"),
                null,
                new FilterTemplateDescriptor(
                    "FilterTemplate",
                    false,
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
                    null
                ),
                null,
                new AggregateTemplateDescriptor(
                    "GroupHeaderTemplate",
                    [
                        new AggregateTemplateFieldsDescriptor("Count", "count")
                    ]
                ),
                null,
                null,
                typeof(string).AssemblyQualifiedName
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<ColumnSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.Type, deserializedDescriptor.Type);
            Assert.Equal(descriptor.Groupable, deserializedDescriptor.Groupable);
            Assert.Equal(descriptor.Width, deserializedDescriptor.Width);
            Assert.Equal(descriptor.Filter, deserializedDescriptor.Filter);
            Assert.NotNull(deserializedDescriptor.CellTemplate);
            Assert.NotNull(deserializedDescriptor.FilterRowTemplate);
            Assert.NotNull(deserializedDescriptor.GroupHeaderTemplate);
        }
    }
}
