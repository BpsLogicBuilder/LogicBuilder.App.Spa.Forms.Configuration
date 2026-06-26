using LogicBuilder.Expressions.Utils.Json;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common.Json
{
    public class FormItemSettingDescriptorConverter : JsonTypeConverter<FormItemSettingDescriptor>
    {
        public override string TypePropertyName => nameof(FormItemSettingDescriptor.TypeString);
    }
}
