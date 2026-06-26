namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class ContentTemplateDescriptor(string title, string templateName)
    {
        public string Title { get; } = title;
        public string TemplateName { get; } = templateName;
    }
}