using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
#pragma warning disable S107 //Parameters used to configure a grid with several optional settings
    public class GridSettingsDescriptor(string title, bool sortable, bool pageable, string scrollable, bool groupable, bool isFilterable, string filterableType, List<ColumnSettingsDescriptor> columns, int? gridId, int? height, CommandColumnDescriptor? commandColumn, DataRequestStateDescriptor? state, List<AggregateDefinitionDescriptor>? aggregates, GridRequestDetailsDescriptor? requestDetails, GridSettingsDescriptor? detailGridSettings)
#pragma warning restore S107
    {
        public string Title { get; } = title;
        public bool Sortable { get; } = sortable;
        public bool Pageable { get; } = pageable;
        public string Scrollable { get; } = scrollable;
        public bool Groupable { get; } = groupable;
        public bool IsFilterable { get; } = isFilterable;
        public string FilterableType { get; } = filterableType;
        public object Filterable => string.IsNullOrEmpty(FilterableType)
                                        ? (object)IsFilterable
                                        : FilterableType;
        public List<ColumnSettingsDescriptor> Columns { get; } = columns;
        public int? GridId { get; } = gridId;
        public int? Height { get; } = height;
        public CommandColumnDescriptor? CommandColumn { get; } = commandColumn;
        public DataRequestStateDescriptor? State { get; } = state;
        public List<AggregateDefinitionDescriptor>? Aggregates { get; } = aggregates;
        public GridRequestDetailsDescriptor? RequestDetails { get; } = requestDetails;
        public GridSettingsDescriptor? DetailGridSettings { get; } = detailGridSettings;
    }
}