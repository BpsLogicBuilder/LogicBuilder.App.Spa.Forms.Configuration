using LogicBuilder.Expressions.Utils.ExpressionDescriptors;
using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class ListFormSettingsDescriptor(string title, RequestDetailsDescriptor requestDetails, SelectorLambdaDescriptor fieldsSelector, List<DetailItemDescriptor> fieldSettings)
    {
        public string Title { get; } = title;
        public RequestDetailsDescriptor RequestDetails { get; } = requestDetails;
        public SelectorLambdaDescriptor FieldsSelector { get; } = fieldsSelector;
        public List<DetailItemDescriptor> FieldSettings { get; } = fieldSettings;
    }
}