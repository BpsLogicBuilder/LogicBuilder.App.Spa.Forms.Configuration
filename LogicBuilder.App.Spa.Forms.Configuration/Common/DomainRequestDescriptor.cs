namespace LogicBuilder.App.Spa.Forms.Configuration.Common
{
    public class DomainRequestDescriptor(DataRequestStateDescriptor state, RequestDetailsDescriptor requestDetails)
    {
        public DataRequestStateDescriptor State { get; } = state;
        public RequestDetailsDescriptor RequestDetails { get; } = requestDetails;
    }
}