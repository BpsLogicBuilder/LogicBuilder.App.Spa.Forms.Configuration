namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class AggregateDefinitionDescriptor(string field, string aggregate, string? modelType)
    {
        public string Field { get; } = field;
        public string Aggregate { get; } = aggregate;
        public string? ModelType { get; } = modelType;
    }
}