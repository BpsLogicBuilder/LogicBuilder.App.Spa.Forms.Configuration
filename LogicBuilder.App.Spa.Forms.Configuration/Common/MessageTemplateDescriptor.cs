namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class MessageTemplateDescriptor(string caption, string message, string templateName)
    {
        public string Caption { get; } = caption;
        public string Message { get; } = message;
        public string TemplateName { get; } = templateName;
    }
}