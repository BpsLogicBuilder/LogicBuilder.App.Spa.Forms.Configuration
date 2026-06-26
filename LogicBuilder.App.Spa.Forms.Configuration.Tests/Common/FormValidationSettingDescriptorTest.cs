using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class FormValidationSettingDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeFormValidationSettingDescriptor()
        {
            // Arrange
            var descriptor = new FormValidationSettingDescriptor(
                "DefaultValue",
                [
                    new ValidatorDescriptionDescriptor(
                        "ValidatorClass",
                        "Required",
                        new Dictionary<string, object>
                        {
                            { "message", "This field is required" }
                        }
                    ),
                    new ValidatorDescriptionDescriptor(
                        "ValidatorClass",
                        "MaxLength",
                        new Dictionary<string, object>
                        {
                            { "length", 100 },
                            { "message", "Maximum length is 100 characters" }
                        }
                    )
                ]
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<FormValidationSettingDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.DefaultValue?.ToString(), deserializedDescriptor.DefaultValue?.ToString());
            Assert.NotNull(deserializedDescriptor.Validators);
            Assert.Equal(2, deserializedDescriptor.Validators.Count);
        }
    }
}
