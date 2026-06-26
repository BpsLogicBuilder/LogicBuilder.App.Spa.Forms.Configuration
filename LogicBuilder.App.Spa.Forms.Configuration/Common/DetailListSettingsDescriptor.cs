using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class DetailListSettingsDescriptor(DetailItemType detailType, string field, string title, DetailListTemplateDescriptor listTemplate, List<DetailItemDescriptor> fieldSettings, string? modelType) : DetailItemDescriptor
    {
        public override DetailItemType DetailType { get; } = detailType;
        public string Field { get; } = field;
        public string Title { get; } = title;
        public DetailListTemplateDescriptor ListTemplate { get; } = listTemplate;
        public List<DetailItemDescriptor> FieldSettings { get; } = fieldSettings;
        public string? ModelType { get; } = modelType;
    }
}