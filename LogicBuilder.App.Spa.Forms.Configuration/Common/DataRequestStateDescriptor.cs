using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class DataRequestStateDescriptor(int? skip, int? take, List<SortDescriptor>? sort, List<GroupDescriptor>? group, FilterGroupDescriptor? filterGroup, List<AggregateDefinitionDescriptor>? aggregates)
    {
        public int? Skip { get; } = skip;
        public int? Take { get; } = take;
        public List<SortDescriptor>? Sort { get; } = sort;
        public List<GroupDescriptor>? Group { get; } = group;
        public FilterGroupDescriptor? FilterGroup { get; } = filterGroup;
        public List<AggregateDefinitionDescriptor>? Aggregates { get; } = aggregates;
    }
}