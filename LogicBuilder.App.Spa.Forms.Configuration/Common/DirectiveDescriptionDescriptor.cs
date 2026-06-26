using System.Collections.Generic;

namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class DirectiveDescriptionDescriptor(string className, string functionName, Dictionary<string, object> arguments)
    {
        public string ClassName { get; } = className;
        public string FunctionName { get; } = functionName;
        public Dictionary<string, object> Arguments { get; } = arguments;
    }
}