using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class DetailFormSettingsDescriptor(string title, string displayField, FormRequestDetailsDescriptor requestDetails, List<DetailItemDescriptor> fieldSettings, string? modelType)
    {
        public string Title { get; } = title;
        public string DisplayField { get; } = displayField;
        public FormRequestDetailsDescriptor RequestDetails { get; } = requestDetails;
        public List<DetailItemDescriptor> FieldSettings { get; } = fieldSettings;
        public string? ModelType { get; } = modelType;
    }
}