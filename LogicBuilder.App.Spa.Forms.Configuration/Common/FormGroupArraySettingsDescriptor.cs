using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
#pragma warning disable S107 //Parameters used to configure a form group array with several settings
    public class FormGroupArraySettingsDescriptor(AbstractControlType abstractControlType, string field, FormGroupTemplateDescriptor formGroupTemplate, List<FormItemSettingDescriptor> fieldSettings, Dictionary<string, Dictionary<string, string>> validationMessages, List<string> keyFields, Dictionary<string, List<DirectiveDescriptor>> conditionalDirectives, string title, bool showTitle, string arrayElementType) : FormItemSettingDescriptor
#pragma warning restore S107
    {
        public override AbstractControlType AbstractControlType { get; } = abstractControlType;
        public string Field { get; } = field;
        public FormGroupTemplateDescriptor FormGroupTemplate { get; } = formGroupTemplate;
        public List<FormItemSettingDescriptor> FieldSettings { get; } = fieldSettings;
        public Dictionary<string, Dictionary<string, string>> ValidationMessages { get; } = validationMessages;
        public List<string> KeyFields { get; } = keyFields;
        public Dictionary<string, List<DirectiveDescriptor>> ConditionalDirectives { get; } = conditionalDirectives;
        public string Title { get; } = title;
        public bool ShowTitle { get; } = showTitle;
        public string ArrayElementType { get; } = arrayElementType;
    }
}