using LogicBuilder.Expressions.Utils.ExpressionDescriptors;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class MultiSelectTemplateDescriptor(string templateName, string placeHolderText, string textField, string valueField, SelectorLambdaDescriptor textAndValueSelector, RequestDetailsDescriptor requestDetails, string modelType)
    {
        public string TemplateName { get; } = templateName;
        public string PlaceHolderText { get; } = placeHolderText;
        public string TextField { get; } = textField;
        public string ValueField { get; } = valueField;
        public SelectorLambdaDescriptor TextAndValueSelector { get; } = textAndValueSelector;
        public RequestDetailsDescriptor RequestDetails { get; } = requestDetails;
        public string ModelType { get; } = modelType;
    }
}