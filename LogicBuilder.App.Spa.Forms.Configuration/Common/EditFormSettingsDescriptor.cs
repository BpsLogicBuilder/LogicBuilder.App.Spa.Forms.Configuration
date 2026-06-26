using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class EditFormSettingsDescriptor(string title, string displayField, FormRequestDetailsDescriptor requestDetails, Dictionary<string, Dictionary<string, string>> validationMessages, List<FormItemSettingDescriptor> fieldSettings, Dictionary<string, List<DirectiveDescriptor>> conditionalDirectives, string modelType)
    {
        public string Title { get; } = title;
        public string DisplayField { get; } = displayField;
        public FormRequestDetailsDescriptor RequestDetails { get; } = requestDetails;
        public Dictionary<string, Dictionary<string, string>> ValidationMessages { get; } = validationMessages;
        public List<FormItemSettingDescriptor> FieldSettings { get; } = fieldSettings;
        public Dictionary<string, List<DirectiveDescriptor>> ConditionalDirectives { get; } = conditionalDirectives;
        public string ModelType { get; } = modelType;
    }
}