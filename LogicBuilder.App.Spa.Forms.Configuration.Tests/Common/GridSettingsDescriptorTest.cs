using LogicBuilder.App.Spa.Forms.Configuration.Common;
using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using LogicBuilder.Expressions.Utils.ExpansionDescriptors;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class GridSettingsDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeGridSettingsDescriptor()
        {
            // Arrange
            var descriptor = new GridSettingsDescriptor(
                "Person Grid",
                true,
                true,
                "virtual",
                true,
                true,
                "menu",
                [
                    new ColumnSettingsDescriptor(
                        "Name",
                        "Full Name",
                        "string",
                        true,
                        200,
                        null,
                        "text",
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        null,
                        typeof(string).AssemblyQualifiedName
                    )
                ],
                1,
                600,
                new CommandColumnDescriptor("Actions", 150),
                new DataRequestStateDescriptor(0, 10, null, null, null, null),
                [
                    new AggregateDefinitionDescriptor("Count", "count", null)
                ],
                new GridRequestDetailsDescriptor(
                    "MyNamespace.Person",
                    "MyNamespace.PersonData",
                    "/api/persons",
                    null
                ),
                null
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<GridSettingsDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.Title, deserializedDescriptor.Title);
            Assert.Equal(descriptor.Sortable, deserializedDescriptor.Sortable);
            Assert.Equal(descriptor.Pageable, deserializedDescriptor.Pageable);
            Assert.Equal(descriptor.Scrollable, deserializedDescriptor.Scrollable);
            Assert.Equal(descriptor.Groupable, deserializedDescriptor.Groupable);
            Assert.Equal(descriptor.IsFilterable, deserializedDescriptor.IsFilterable);
            Assert.Equal(descriptor.FilterableType, deserializedDescriptor.FilterableType);
            Assert.NotNull(deserializedDescriptor.Columns);
            Assert.Single(deserializedDescriptor.Columns);
            Assert.Equal(descriptor.GridId, deserializedDescriptor.GridId);
            Assert.Equal(descriptor.Height, deserializedDescriptor.Height);
            Assert.NotNull(deserializedDescriptor.CommandColumn);
            Assert.NotNull(deserializedDescriptor.State);
            Assert.NotNull(deserializedDescriptor.Aggregates);
            Assert.NotNull(deserializedDescriptor.RequestDetails);
        }

        [Fact]
        public void FilterableProperty_ReturnsIsFilterable_WhenFilterableTypeIsEmpty()
        {
            // Arrange - FilterableType is empty string
            var descriptor = new GridSettingsDescriptor(
                "Person Grid",
                true,
                true,
                "virtual",
                true,
                true,
                "", // Empty FilterableType
                [],
                1,
                600,
                null,
                null,
                null,
                null,
                null
            );

            // Assert - Should return IsFilterable (bool) when FilterableType is empty
            Assert.IsType<bool>(descriptor.Filterable);
            Assert.True((bool)descriptor.Filterable);
        }

        [Fact]
        public void FilterableProperty_ReturnsFilterableType_WhenFilterableTypeIsNotEmpty()
        {
            // Arrange - FilterableType has a value
            var descriptor = new GridSettingsDescriptor(
                "Person Grid",
                true,
                true,
                "virtual",
                true,
                false, // IsFilterable is false
                "menu", // Non-empty FilterableType
                [],
                1,
                600,
                null,
                null,
                null,
                null,
                null
            );

            // Assert - Should return FilterableType (string) when FilterableType is not empty
            Assert.IsType<string>(descriptor.Filterable);
            Assert.Equal("menu", descriptor.Filterable);
        }
    }
}
