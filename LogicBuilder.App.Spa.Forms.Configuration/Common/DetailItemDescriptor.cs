using LogicBuilder.App.Spa.Forms.Configuration.Common.Json;
using System.Text.Json.Serialization;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    [JsonConverter(typeof(DetailItemDescriptorConverter))]
    abstract public class DetailItemDescriptor
    {
		abstract public DetailItemType DetailType { get; }
        public string TypeString => this.GetType().AssemblyQualifiedName;
    }
}