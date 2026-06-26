namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class DirectiveArgumentDescriptor(string name, object value)
    {
        public string Name { get; } = name;
        public object Value { get; } = value;
    }
}