namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class ChatFormSettingsDescriptor(
        string agentConfigurationIdentifier,
        int chatHeight,
        int chatWidth,
        SignalRConnectionDescriptor signalRConnection)
    {
        public string AgentConfigurationIdentifier { get; } = agentConfigurationIdentifier;
        public int ChatHeight { get; } = chatHeight;
        public int ChatWidth { get; } = chatWidth;
        public SignalRConnectionDescriptor SignalRConnection { get; } = signalRConnection;
    }
}
