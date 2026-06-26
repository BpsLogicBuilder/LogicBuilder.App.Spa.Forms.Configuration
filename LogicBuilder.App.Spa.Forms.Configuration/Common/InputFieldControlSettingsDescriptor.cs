namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
#pragma warning disable S107 //Parameters used to configure a control with several optional settings
    public class InputFieldControlSettingsDescriptor(AbstractControlType abstractControlType, string field, string domElementId, string title, string placeholder, string type, TextFieldTemplateDescriptor textTemplate, string modelType, FormValidationSettingDescriptor? validationSetting) : FormItemSettingDescriptor
#pragma warning restore S107
    {
        public override AbstractControlType AbstractControlType { get; } = abstractControlType;
        public string Field { get; } = field;
        public string DomElementId { get; } = domElementId;
        public string Title { get; } = title;
        public string Placeholder { get; } = placeholder;
        public string Type { get; } = type;
        public TextFieldTemplateDescriptor TextTemplate { get; } = textTemplate;
        public string ModelType { get; } = modelType;
        public FormValidationSettingDescriptor? ValidationSetting { get; } = validationSetting;
        public FormValidationSettingDescriptor? UnchangedValidationSetting => ValidationSetting;
    }
}
