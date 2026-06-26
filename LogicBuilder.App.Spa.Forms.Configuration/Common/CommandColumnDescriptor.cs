namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class CommandColumnDescriptor(string title, int? width)
    {
        public string Title { get; } = title;
        public int? Width { get; } = width;
    }
}