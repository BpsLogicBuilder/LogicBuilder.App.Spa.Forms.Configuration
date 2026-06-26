using LogicBuilder.App.Spa.Forms.Configuration.Common.Json;
using LogicBuilder.Expressions.Utils.Json;
using System.Text.Json;

namespace LogicBuilder.App.Spa.Forms.Configuration.Tests
{
    public static class SerializationOptions
    {
        private static readonly JsonSerializerOptions _default = CreateSerializationOptions();

        public static JsonSerializerOptions Default
        {
            get
            {
                return _default;
            }
        }

        static JsonSerializerOptions CreateSerializationOptions()
        {
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            options.Converters.Add(new DescriptorConverter());
            options.Converters.Add(new DetailItemDescriptorConverter());
            options.Converters.Add(new FormItemSettingDescriptorConverter());
            return options;
        }
    }
}
