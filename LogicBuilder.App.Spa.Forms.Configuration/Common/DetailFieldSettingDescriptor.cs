namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class DetailFieldSettingDescriptor(DetailItemType detailType, string field, string title, string type, string modelType, DetailFieldTemplateDescriptor fieldTemplate, DetailDropDownTemplateDescriptor valueTextTemplate) : DetailItemDescriptor
    {
        public override DetailItemType DetailType { get; } = detailType;
        public string Field { get; } = field;
        public string Title { get; } = title;
        public string Type { get; } = type;
        public string ModelType { get; } = modelType;
        public DetailFieldTemplateDescriptor FieldTemplate { get; } = fieldTemplate;
        public DetailDropDownTemplateDescriptor ValueTextTemplate { get; } = valueTextTemplate;
    }
}