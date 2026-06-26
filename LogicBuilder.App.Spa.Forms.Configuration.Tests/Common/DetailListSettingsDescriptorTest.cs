using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DetailListSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDetailListSettingsDescriptor()
        {
            // Arrange
            const string parameterName = "p";
            var descriptor = new DetailListSettingsDescriptor(
                DetailItemType.List,
                "Orders",
                "Order List",
                new DetailListTemplateDescriptor("ListTemplate"),
                [
                    new DetailFieldSettingDescriptor(
                        DetailItemType.Field,
                        "OrderId",
                        "Order ID",
                        "int",
                        "MyNamespace.Order",
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
                                "MyNamespace.Order",
                                "MyNamespace.OrderData",
                                "MyNamespace.Order",
                                "MyNamespace.OrderData",
                                "/api/orders",
                                null
                            ),
                            null,
                            "MyNamespace.Order"
                        )
                    )
                ],
                "MyNamespace.Order"
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DetailListSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.DetailType, deserializedDescriptor.DetailType);
            Assert.Equal(descriptor.Field, deserializedDescriptor.Field);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.NotNull(deserializedDescriptor.ListTemplate);
            Assert.NotNull(deserializedDescriptor.FieldSettings);
            Assert.Single(deserializedDescriptor.FieldSettings);
            Assert.Equal(descriptor.ModelType, deserializedDescriptor.ModelType);
        }
    }
}
