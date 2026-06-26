using LogicBuilder.Expressions.Utils.ExpressionDescriptors;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class FilterTemplateDescriptor(string templateName, bool isPrimitive, string textField, string valueField, SelectorLambdaDescriptor textAndValueSelector, RequestDetailsDescriptor requestDetails, string? modelType)
    {
        public string TemplateName { get; } = templateName;
        public bool IsPrimitive { get; } = isPrimitive;
        public string TextField { get; } = textField;
        public string ValueField { get; } = valueField;
        public SelectorLambdaDescriptor TextAndValueSelector { get; } = textAndValueSelector;
        public RequestDetailsDescriptor RequestDetails { get; } = requestDetails;
        public string? ModelType { get; } = modelType;
    }
}