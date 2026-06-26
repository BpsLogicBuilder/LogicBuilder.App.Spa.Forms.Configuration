namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
#pragma warning disable S107 //Parameters used to configure a column with several optional settings
    public class ColumnSettingsDescriptor(string field, string title, string type, bool? groupable, int? width, string? format, string? filter, CellTemplateDescriptor? cellTemplate, CellListTemplateDescriptor? cellListTemplate, FilterTemplateDescriptor? filterRowTemplate, FilterTemplateDescriptor? filterMenuTemplate, AggregateTemplateDescriptor? groupHeaderTemplate, AggregateTemplateDescriptor? groupFooterTemplate, AggregateTemplateDescriptor? gridFooterTemplate, string? modelType)
#pragma warning restore S107
    {
        public string Field { get; } = field;
        public string Title { get; } = title;
        public string Type { get; } = type;
        public bool? Groupable { get; } = groupable;
        public int? Width { get; } = width;
        public string? Format { get; } = format;
        public string? Filter { get; } = filter;
        public CellTemplateDescriptor? CellTemplate { get; } = cellTemplate;
        public CellListTemplateDescriptor? CellListTemplate { get; } = cellListTemplate;
        public FilterTemplateDescriptor? FilterRowTemplate { get; } = filterRowTemplate;
        public FilterTemplateDescriptor? FilterMenuTemplate { get; } = filterMenuTemplate;
        public AggregateTemplateDescriptor? GroupHeaderTemplate { get; } = groupHeaderTemplate;
        public AggregateTemplateDescriptor? GroupFooterTemplate { get; } = groupFooterTemplate;
        public AggregateTemplateDescriptor? GridFooterTemplate { get; } = gridFooterTemplate;
        public string? ModelType { get; } = modelType;
    }
}