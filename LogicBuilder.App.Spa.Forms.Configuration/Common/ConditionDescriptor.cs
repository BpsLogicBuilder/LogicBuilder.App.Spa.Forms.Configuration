namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class ConditionDescriptor(string @operator, string leftVariable, string? rightVariable, object? value, string? modelType)
    {
        public string Operator { get; } = @operator;
        public string LeftVariable { get; } = leftVariable;
        public string? RightVariable { get; } = rightVariable;
        public object? Value { get; } = value;
        public string? ModelType { get; } = modelType;
    }
}