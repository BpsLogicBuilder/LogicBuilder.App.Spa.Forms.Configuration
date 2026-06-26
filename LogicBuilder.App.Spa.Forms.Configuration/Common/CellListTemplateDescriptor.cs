namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class CellListTemplateDescriptor(string templateName, string displayMember, string? modelType)
    {
        public string TemplateName { get; } = templateName;
        public string DisplayMember { get; } = displayMember;
        public string? ModelType { get; } = modelType;
    }
}