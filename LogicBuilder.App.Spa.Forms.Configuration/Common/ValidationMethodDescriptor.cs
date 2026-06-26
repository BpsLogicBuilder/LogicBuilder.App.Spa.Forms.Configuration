namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class ValidationMethodDescriptor(string method, string message)
    {
        public string Method { get; } = method;
        public string Message { get; } = message;
    }
}