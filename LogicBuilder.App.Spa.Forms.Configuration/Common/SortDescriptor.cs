namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class SortDescriptor(string field, string dir, string? modelType)
    {
        public string Field { get; } = field;
        public string Dir { get; } = dir;
        public string? ModelType { get; } = modelType;
    }
}