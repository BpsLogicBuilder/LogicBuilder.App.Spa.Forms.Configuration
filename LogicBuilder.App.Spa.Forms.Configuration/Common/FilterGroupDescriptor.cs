using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class FilterGroupDescriptor(string logic, List<FilterDefinitionDescriptor>? filters, List<FilterGroupDescriptor>? filterGroups)
    {
        public string Logic { get; } = logic;
        public List<FilterDefinitionDescriptor>? Filters { get; } = filters;
        public List<FilterGroupDescriptor>? FilterGroups { get; } = filterGroups;
    }
}