using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class FormGroupBoxSettingsDescriptor(AbstractControlType abstractControlType, FormGroupTemplateDescriptor formGroupTemplate, List<FormItemSettingDescriptor> fieldSettings, string title, bool showTitle) : FormItemSettingDescriptor
	{
        public override AbstractControlType AbstractControlType { get; } = abstractControlType;
        public FormGroupTemplateDescriptor FormGroupTemplate { get; } = formGroupTemplate;
        public List<FormItemSettingDescriptor> FieldSettings { get; } = fieldSettings;
        public string Title { get; } = title;
        public bool ShowTitle { get; } = showTitle;
    }
}
