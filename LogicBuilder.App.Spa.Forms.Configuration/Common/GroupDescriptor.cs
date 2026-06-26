using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class GroupDescriptor(string field, string dir, List<AggregateDefinitionDescriptor> aggregates, string? modelType)
    {
        public string Field { get; } = field;
        public string Dir { get; } = dir;
        public List<AggregateDefinitionDescriptor> Aggregates { get; } = aggregates;
        public string? ModelType { get; } = modelType;
    }
}