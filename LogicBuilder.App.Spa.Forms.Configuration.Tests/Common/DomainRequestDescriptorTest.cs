using LogicBuilder.App.Spa.Forms.Configuration.Common;
using System.Text.Json;
using Xunit;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests.Common
{
    public class DomainRequestDescriptorTest
    {
        [Fact]
        public void CanSerializeAndDeserializeDomainRequestDescriptor()
        {
            // Arrange
            var descriptor = new DomainRequestDescriptor(
                new DataRequestStateDescriptor(
                    0,
                    10,
                    null,
                    null,
                    null,
                    null
                ),
                new RequestDetailsDescriptor(
                    "MyNamespace.Person",
                    "MyNamespace.PersonData",
                    "MyNamespace.Person",
                    "MyNamespace.PersonData",
                    "/api/persons",
                    null
                )
            );

            // Act
            var json = JsonSerializer.Serialize(descriptor);
            var deserializedDescriptor = JsonSerializer.Deserialize<DomainRequestDescriptor>(json, SerializationOptions.Default);

            // Assert
            Assert.NotNull(deserializedDescriptor);
            Assert.NotNull(deserializedDescriptor.State);
            Assert.NotNull(deserializedDescriptor.RequestDetails);
            Assert.Equal(descriptor.State.Skip, deserializedDescriptor.State.Skip);
            Assert.Equal(descriptor.State.Take, deserializedDescriptor.State.Take);
            Assert.Equal(descriptor.RequestDetails.ModelType, deserializedDescriptor.RequestDetails.ModelType);
        }
    }
}
