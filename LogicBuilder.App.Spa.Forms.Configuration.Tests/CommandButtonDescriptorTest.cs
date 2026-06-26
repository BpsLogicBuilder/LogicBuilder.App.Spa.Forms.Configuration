using System;
using System.Text.Json;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests
{
    public class CommandButtonDescriptorTest
    {
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };

        [Fact]
        public void SerializeAndDeserialize_WithAllProperties_ReturnsEqualObject()
        {
            // Arrange
            var original = new CommandButtonDescriptor(
                id: 1,
                shortString: "OK",
                longString: "Click OK to continue",
                cancel: false,
                gridId: 100,
                gridCommandButton: true,
                buttonIcon: "icon-ok",
                classString: "btn-primary"
            );

            // Act
            string json = JsonSerializer.Serialize(original);
            var deserialized = JsonSerializer.Deserialize<CommandButtonDescriptor>(json);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Id, deserialized.Id);
            Assert.Equal(original.ShortString, deserialized.ShortString);
            Assert.Equal(original.LongString, deserialized.LongString);
            Assert.Equal(original.Cancel, deserialized.Cancel);
            Assert.Equal(original.GridId, deserialized.GridId);
            Assert.Equal(original.GridCommandButton, deserialized.GridCommandButton);
            Assert.Equal(original.ButtonIcon, deserialized.ButtonIcon);
            Assert.Equal(original.ClassString, deserialized.ClassString);
        }

        [Fact]
        public void SerializeAndDeserialize_WithNullablePropertiesNull_ReturnsEqualObject()
        {
            // Arrange
            var original = new CommandButtonDescriptor(
                id: 2,
                shortString: "Cancel",
                longString: "Cancel operation",
                cancel: true,
                gridId: null,
                gridCommandButton: null,
                buttonIcon: "icon-cancel",
                classString: "btn-secondary"
            );

            // Act
            string json = JsonSerializer.Serialize(original);
            var deserialized = JsonSerializer.Deserialize<CommandButtonDescriptor>(json);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(original.Id, deserialized.Id);
            Assert.Equal(original.ShortString, deserialized.ShortString);
            Assert.Equal(original.LongString, deserialized.LongString);
            Assert.Equal(original.Cancel, deserialized.Cancel);
            Assert.Null(deserialized.GridId);
            Assert.Null(deserialized.GridCommandButton);
            Assert.Equal(original.ButtonIcon, deserialized.ButtonIcon);
            Assert.Equal(original.ClassString, deserialized.ClassString);
        }

        [Fact]
        public void Serialize_ProducesExpectedJsonStructure()
        {
            // Arrange
            var descriptor = new CommandButtonDescriptor(
                id: 3,
                shortString: "Submit",
                longString: "Submit form",
                cancel: false,
                gridId: 200,
                gridCommandButton: false,
                buttonIcon: "icon-submit",
                classString: "btn-success"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor);
            var jsonDocument = JsonDocument.Parse(json);

            // Assert
            Assert.Equal(3, jsonDocument.RootElement.GetProperty("Id").GetInt32());
            Assert.Equal("Submit", jsonDocument.RootElement.GetProperty("ShortString").GetString());
            Assert.Equal("Submit form", jsonDocument.RootElement.GetProperty("LongString").GetString());
            Assert.False(jsonDocument.RootElement.GetProperty("Cancel").GetBoolean());
            Assert.Equal(200, jsonDocument.RootElement.GetProperty("GridId").GetInt32());
            Assert.False(jsonDocument.RootElement.GetProperty("GridCommandButton").GetBoolean());
            Assert.Equal("icon-submit", jsonDocument.RootElement.GetProperty("ButtonIcon").GetString());
            Assert.Equal("btn-success", jsonDocument.RootElement.GetProperty("ClassString").GetString());
        }

        [Fact]
        public void Deserialize_FromValidJson_CreatesCorrectObject()
        {
            // Arrange
            string json = @"{
                ""Id"": 4,
                ""ShortString"": ""Delete"",
                ""LongString"": ""Delete item"",
                ""Cancel"": false,
                ""GridId"": 300,
                ""GridCommandButton"": true,
                ""ButtonIcon"": ""icon-delete"",
                ""ClassString"": ""btn-danger""
            }";

            // Act
            var descriptor = JsonSerializer.Deserialize<CommandButtonDescriptor>(json);

            // Assert
            Assert.NotNull(descriptor);
            Assert.Equal(4, descriptor.Id);
            Assert.Equal("Delete", descriptor.ShortString);
            Assert.Equal("Delete item", descriptor.LongString);
            Assert.False(descriptor.Cancel);
            Assert.Equal(300, descriptor.GridId);
            Assert.True(descriptor.GridCommandButton);
            Assert.Equal("icon-delete", descriptor.ButtonIcon);
            Assert.Equal("btn-danger", descriptor.ClassString);
        }

        [Fact]
        public void Serialize_WithCustomOptions_UsesCorrectFormatting()
        {
            // Arrange
            var descriptor = new CommandButtonDescriptor(
                id: 5,
                shortString: "Edit",
                longString: "Edit record",
                cancel: false,
                gridId: null,
                gridCommandButton: null,
                buttonIcon: "icon-edit",
                classString: "btn-info"
            );

            // Act
            string json = JsonSerializer.Serialize(descriptor, options);

            // Assert
            Assert.Contains("\"Id\": 5", json);
            Assert.Contains("\"ShortString\": \"Edit\"", json);
            Assert.Contains(Environment.NewLine, json); // Verifies indentation
        }

        [Fact]
        public void SerializeAndDeserialize_WithEmptyStrings_PreservesValues()
        {
            // Arrange
            var original = new CommandButtonDescriptor(
                id: 6,
                shortString: string.Empty,
                longString: string.Empty,
                cancel: true,
                gridId: 0,
                gridCommandButton: false,
                buttonIcon: string.Empty,
                classString: string.Empty
            );

            // Act
            string json = JsonSerializer.Serialize(original);
            var deserialized = JsonSerializer.Deserialize<CommandButtonDescriptor>(json);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(string.Empty, deserialized.ShortString);
            Assert.Equal(string.Empty, deserialized.LongString);
            Assert.Equal(string.Empty, deserialized.ButtonIcon);
            Assert.Equal(string.Empty, deserialized.ClassString);
        }

        [Fact]
        public void SerializeAndDeserialize_RoundTrip_MultipleInstances()
        {
            // Arrange
            var descriptors = new[]
            {
                new CommandButtonDescriptor(1, "Save", "Save changes", false, 100, true, "icon-save", "btn-primary"),
                new CommandButtonDescriptor(2, "Cancel", "Cancel operation", true, null, null, "icon-cancel", "btn-secondary"),
                new CommandButtonDescriptor(3, "Apply", "Apply settings", false, 200, false, "icon-apply", "btn-success")
            };

            // Act
            string json = JsonSerializer.Serialize(descriptors);
            var deserialized = JsonSerializer.Deserialize<CommandButtonDescriptor[]>(json);

            // Assert
            Assert.NotNull(deserialized);
            Assert.Equal(descriptors.Length, deserialized.Length);
            for (int i = 0; i < descriptors.Length; i++)
            {
                Assert.Equal(descriptors[i].Id, deserialized[i].Id);
                Assert.Equal(descriptors[i].ShortString, deserialized[i].ShortString);
                Assert.Equal(descriptors[i].LongString, deserialized[i].LongString);
                Assert.Equal(descriptors[i].Cancel, deserialized[i].Cancel);
                Assert.Equal(descriptors[i].GridId, deserialized[i].GridId);
                Assert.Equal(descriptors[i].GridCommandButton, deserialized[i].GridCommandButton);
                Assert.Equal(descriptors[i].ButtonIcon, deserialized[i].ButtonIcon);
                Assert.Equal(descriptors[i].ClassString, deserialized[i].ClassString);
            }
        }
    }
}
