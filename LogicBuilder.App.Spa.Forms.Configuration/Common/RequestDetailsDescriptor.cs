using LogicBuilder.Expressions.Utils.ExpansionDescriptors;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class RequestDetailsDescriptor(string modelType, string dataType, string modelReturnType, string dataReturnType, string dataSourceUrl, SelectExpandDefinitionDescriptor? selectExpandDefinition)
    {
        public string ModelType { get; } = modelType;
        public string DataType { get; } = dataType;
        public string ModelReturnType { get; } = modelReturnType;
        public string DataReturnType { get; } = dataReturnType;
        public string DataSourceUrl { get; } = dataSourceUrl;
        public SelectExpandDefinitionDescriptor? SelectExpandDefinition { get; } = selectExpandDefinition;
    }
}