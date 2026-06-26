namespace LogicBuilder.App.Spa.Forms.Configuration
{
#pragma warning disable S107 //Parameters used to configure a button with several ettings
    public class CommandButtonDescriptor(int id, string shortString, string longString, bool cancel, int? gridId, bool? gridCommandButton, string buttonIcon, string classString)
#pragma warning restore S107
    {
        public int Id { get; } = id;
        public string ShortString { get; } = shortString;
        public string LongString { get; } = longString;
        public bool Cancel { get; } = cancel;
        public int? GridId { get; } = gridId;
        public bool? GridCommandButton { get; } = gridCommandButton;
        public string ButtonIcon { get; } = buttonIcon;
        public string ClassString { get; } = classString;
    }
}
