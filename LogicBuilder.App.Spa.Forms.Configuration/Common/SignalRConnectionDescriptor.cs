namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class SignalRConnectionDescriptor(
        string agentHubUrl,
        string receiveAgentErrorHandler,
        string receiveAgentMessageHandler,
        string receiveAgentResponseCompleteHandler,
        string sendMessageToAgentHubMethodName,
        string sessionInitializedHandler)
    {
        public string AgentHubUrl { get; } = agentHubUrl;
        public string ReceiveAgentErrorHandler { get; } = receiveAgentErrorHandler;
        public string ReceiveAgentMessageHandler { get; } = receiveAgentMessageHandler;
        public string ReceiveAgentResponseCompleteHandler { get; } = receiveAgentResponseCompleteHandler;
        public string SendMessageToAgentHubMethodName { get; } = sendMessageToAgentHubMethodName;
        public string SessionInitializedHandler { get; } = sessionInitializedHandler;
    }
}
