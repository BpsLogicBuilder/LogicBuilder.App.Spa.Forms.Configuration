using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
#pragma warning disable S107 //Parameters used to configure a control with several optional settings
    public class MultiSelectFormControlSettingsDescriptor(AbstractControlType abstractControlType, List<string> keyFields, string field, string domElementId, string title, string placeholder, string type, string modelType, MultiSelectTemplateDescriptor multiSelectTemplate, FormValidationSettingDescriptor? validationSetting) : FormItemSettingDescriptor
#pragma warning restore S107
    {
        public override AbstractControlType AbstractControlType { get; } = abstractControlType;
        public List<string> KeyFields { get; } = keyFields;
        public string Field { get; } = field;
        public string DomElementId { get; } = domElementId;
        public string Title { get; } = title;
        public string Placeholder { get; } = placeholder;
        public string Type { get; } = type;
        public string ModelType { get; } = modelType;
        public MultiSelectTemplateDescriptor MultiSelectTemplate { get; } = multiSelectTemplate;
        public FormValidationSettingDescriptor? ValidationSetting { get; } = validationSetting;
        public FormValidationSettingDescriptor? UnchangedValidationSetting => ValidationSetting;
    }
}