namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class DirectiveDescriptor(DirectiveDescriptionDescriptor directiveDescription, ConditionGroupDescriptor conditionGroup)
    {
        public DirectiveDescriptionDescriptor DirectiveDescription { get; } = directiveDescription;
        public ConditionGroupDescriptor ConditionGroup { get; } = conditionGroup;
    }
}