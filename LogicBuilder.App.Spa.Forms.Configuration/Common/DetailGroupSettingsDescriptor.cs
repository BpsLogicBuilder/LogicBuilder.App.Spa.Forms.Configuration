using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class DetailGroupSettingsDescriptor(DetailItemType detailType, string field, string title, DetailGroupTemplateDescriptor groupTemplate, List<DetailItemDescriptor> fieldSettings, string? modelType) : DetailItemDescriptor
    {
        public override DetailItemType DetailType { get; } = detailType;
        public string Field { get; } = field;
        public string Title { get; } = title;
        public DetailGroupTemplateDescriptor GroupTemplate { get; } = groupTemplate;
        public List<DetailItemDescriptor> FieldSettings { get; } = fieldSettings;
        public string? ModelType { get; } = modelType;
    }
}