namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class HtmlPageSettingsDescriptor(ContentTemplateDescriptor? contentTemplate, MessageTemplateDescriptor? messageTemplate)
    {
        public ContentTemplateDescriptor? ContentTemplate { get; } = contentTemplate;
        public MessageTemplateDescriptor? MessageTemplate { get; } = messageTemplate;
    }
}