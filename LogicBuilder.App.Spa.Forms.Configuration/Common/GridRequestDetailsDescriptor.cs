using LogicBuilder.Expressions.Utils.ExpansionDescriptors;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class GridRequestDetailsDescriptor(string modelType, string dataType, string dataSourceUrl, SelectExpandDefinitionDescriptor? selectExpandDefinition)
    {
        public string ModelType { get; } = modelType;
        public string DataType { get; } = dataType;
        public string DataSourceUrl { get; } = dataSourceUrl;
        public SelectExpandDefinitionDescriptor? SelectExpandDefinition { get; } = selectExpandDefinition;
    }
}
