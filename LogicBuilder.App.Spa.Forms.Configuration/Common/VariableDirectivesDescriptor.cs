using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class VariableDirectivesDescriptor(string field, List<DirectiveDescriptor> conditionalDirectives, string? modelType)
    {
        public string Field { get; } = field;
        public List<DirectiveDescriptor> ConditionalDirectives { get; } = conditionalDirectives;
        public string? ModelType { get; } = modelType;
    }
}