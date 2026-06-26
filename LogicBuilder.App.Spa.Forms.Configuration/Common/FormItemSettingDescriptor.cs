using LogicBuilder.App.Spa.Forms.Configuration.Common.Json;
using System.Text.Json.Serialization;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    [JsonConverter(typeof(FormItemSettingDescriptorConverter))]
    abstract public class FormItemSettingDescriptor
    {
		abstract public AbstractControlType AbstractControlType { get; }
        public string TypeString => this.GetType().AssemblyQualifiedName;
    }
}