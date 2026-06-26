using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class FilterDefinitionDescriptor(string field, string @operator, object? value, bool? ignoreCase, string valueSourceMember, string? modelType)
    {
        public string Field { get; } = field;
        public string Operator { get; } = @operator;
        public object? Value { get; } = value;
        public bool? IgnoreCase { get; } = ignoreCase;
        public string ValueSourceMember { get; } = valueSourceMember;
        public string? ModelType { get; } = modelType;
    }
}