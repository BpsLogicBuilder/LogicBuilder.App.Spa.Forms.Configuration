using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class ConditionGroupDescriptor(string logic, List<ConditionDescriptor>? conditions, List<ConditionGroupDescriptor>? conditionGroups)
    {
        public string Logic { get; } = logic;
        public List<ConditionDescriptor>? Conditions { get; } = conditions;
        public List<ConditionGroupDescriptor>? ConditionGroups { get; } = conditionGroups;
    }
}