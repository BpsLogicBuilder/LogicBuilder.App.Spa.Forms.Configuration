using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
#pragma warning disable S107 //Parameters used to configure a form group with several settings
    public class FormGroupSettingsDescriptor(AbstractControlType abstractControlType, string field, FormGroupTemplateDescriptor formGroupTemplate, List<FormItemSettingDescriptor> fieldSettings, Dictionary<string, Dictionary<string, string>> validationMessages, Dictionary<string, List<DirectiveDescriptor>> conditionalDirectives, string title, bool showTitle, string modelType) : FormItemSettingDescriptor
#pragma warning restore S107
    {
        public override AbstractControlType AbstractControlType { get; } = abstractControlType;
        public string Field { get; } = field;
        public FormGroupTemplateDescriptor FormGroupTemplate { get; } = formGroupTemplate;
        public List<FormItemSettingDescriptor> FieldSettings { get; } = fieldSettings;
        public Dictionary<string, Dictionary<string, string>> ValidationMessages { get; } = validationMessages;
        public Dictionary<string, List<DirectiveDescriptor>> ConditionalDirectives { get; } = conditionalDirectives;
        public string Title { get; } = title;
        public bool ShowTitle { get; } = showTitle;
        public string ModelType { get; } = modelType;
    }
}