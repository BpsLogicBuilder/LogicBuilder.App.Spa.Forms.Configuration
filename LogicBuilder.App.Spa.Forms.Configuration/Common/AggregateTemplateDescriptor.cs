using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class AggregateTemplateDescriptor(string templateName, List<AggregateTemplateFieldsDescriptor> aggregates)
    {
        public string TemplateName { get; } = templateName;
        public List<AggregateTemplateFieldsDescriptor> Aggregates { get; } = aggregates;
    }
}