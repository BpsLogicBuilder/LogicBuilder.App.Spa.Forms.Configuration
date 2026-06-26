using LogicBuilder.Expressions.Utils.ExpressionDescriptors;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
#pragma warning disable S107 //Parameters used to configure a dropdown list with several optional settings
    public class DetailDropDownTemplateDescriptor(string templateName, string placeHolderText, string textField, string valueField, SelectorLambdaDescriptor textAndValueSelector, RequestDetailsDescriptor requestDetails, string? reloadItemsFlowName, string? modelType)
#pragma warning restore S107
    {
        public string TemplateName { get; } = templateName;
        public string PlaceHolderText { get; } = placeHolderText;
        public string TextField { get; } = textField;
        public string ValueField { get; } = valueField;
        public SelectorLambdaDescriptor TextAndValueSelector { get; } = textAndValueSelector;
        public RequestDetailsDescriptor RequestDetails { get; } = requestDetails;
        public string? ReloadItemsFlowName { get; } = reloadItemsFlowName;
        public string? ModelType { get; } = modelType;
    }
}