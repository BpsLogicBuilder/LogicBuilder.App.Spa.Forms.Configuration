namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class SelectDescriptor(string fieldName, string sourceMember, string? modelType)
    {
        public string FieldName { get; } = fieldName;
        public string SourceMember { get; } = sourceMember;
        public string? ModelType { get; } = modelType;
    }
}