using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class ValidationMessageDescriptor(string field, Dictionary<string, string> methods, string? modelType)
    {
        public string Field { get; } = field;
        public Dictionary<string, string> Methods { get; } = methods;
        public string? ModelType { get; } = modelType;
    }
}