using LogicBuilder.Expressions.Utils.Json;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common.Json
{
    public class DetailItemDescriptorConverter : JsonTypeConverter<DetailItemDescriptor>
    {
        public override string TypePropertyName => nameof(DetailItemDescriptor.TypeString);
    }
}
