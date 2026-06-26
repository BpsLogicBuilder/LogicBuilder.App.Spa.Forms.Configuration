using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class AggregateTemplateDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeAggregateTemplateDescriptor()
        {
            // Arrange
            var descriptor = new AggregateTemplateDescriptor(
                "AggregateTemplate",
                [
                    new AggregateTemplateFieldsDescriptor("Total", "sum"),
                    new AggregateTemplateFieldsDescriptor("Count", "count")
                ]
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<AggregateTemplateDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.Equal(descriptor.TemplateName, deserializedDescriptor.TemplateName);
            Assert.Equal(descriptor.Aggregates.Count, deserializedDescriptor.Aggregates.Count);
            Assert.Equal(descriptor.Aggregates[0].Label, deserializedDescriptor.Aggregates[0].Label);
            Assert.Equal(descriptor.Aggregates[0].Function, deserializedDescriptor.Aggregates[0].Function);
        }
    }
}
