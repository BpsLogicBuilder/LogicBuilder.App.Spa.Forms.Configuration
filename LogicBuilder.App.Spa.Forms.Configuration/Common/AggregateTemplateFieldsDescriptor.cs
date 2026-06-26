namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class AggregateTemplateFieldsDescriptor(string label, string function)
    {
        public string Label { get; } = label;
        public string Function { get; } = function;
    }
}