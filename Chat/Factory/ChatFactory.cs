namespace ChatClientLibrary.Chat.Factory
{
    using System.Net;

    public abstract class AbstractChatFactory
    {
        public abstract string Address { get; set; }
        public abstract int Port { get; }
    }

    public abstract class ConcreteChatFactory : AbstractChatFactory
    {
        private int _port = 8000;
        private string _address = "127.0.0.1";

        public override string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public override int Port
        {
            get { return this._port; }
        }

        public abstract IChatClient CreateConnection();
    }

    public class ChatFactory : ConcreteChatFactory
    {
        public ChatFactory()
        {

        }

        public ChatFactory(string address)
        {
            this.Address = address;
        }

        public override IChatClient CreateConnection()
        {
            ChatConnection connection = ChatConnection.InstanceContext;
            connection.SetConnection(this);
            return (IChatClient)new ChatClientManager(connection);
        }
    }
}
