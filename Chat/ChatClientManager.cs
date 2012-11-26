namespace ChatClientLibrary.Chat
{
    using System;
    using ChatClientLibrary.Chat.Action;
    using ChatClientLibrary.Chat.ChatUser;
    using ChatClientLibrary.Chat.Collection;

    public class ChatClientManager : IChatClient, IDisposable
    {
        public event NewMessageEventHandler NewMessageEvent;
        public event NewUserEventHandler NewUserEvent;
        public event LogEventHandler LogEvent;
        public event UserLeaveEventHandler UserLeaveEvent;

        private bool _disposing = false;
        private ChatConnection _connection = default(ChatConnection);
        private UserCollection _collection = default(UserCollection);

        public ChatClientManager(ChatConnection connection)
        {
            this._connection = connection;
            this._connection.InternalLogEvent += connectionInternalLogEvent;
            this._connection.InternalNewMessageEvent += connectionInternalNewMessageEvent;
            this._connection.InternalNewUserEvent += connectionInternalNewUserEvent;

            this._collection = UserCollection.InstanceContext;
        }

        #region Connection Members

        private void connectionInternalNewUserEvent(object sender, Events.NewUserEventArgs e)
        {
            if (e != null)
            {
                this._collection.Add(e.User);
                if (this.NewUserEvent != null)
                    this.NewUserEvent(this, e);
                if (this.LogEvent != null)
                    this.LogEvent(this, new Events.LogEventArgs(string.Format("New user joined [ {0} ]", e.User.Username)));
            }
        }

        private void connectionInternalNewMessageEvent(object sender, Events.NewMessageEventArgs e)
        {
            if (e != null)
            {
                e.Sender = this._collection.Get(e.From);
                if (this.NewMessageEvent != null)
                    this.NewMessageEvent(this, e);
                if (this.LogEvent != null)
                    this.LogEvent(this, new Events.LogEventArgs(string.Format("New message Arrived from [ {0} ]", e.Sender.Username)));
            }   
        }

        private void connectionInternalLogEvent(object sender, Events.LogEventArgs e)
        {
            if (this.LogEvent != null)
                this.LogEvent(this, e);
        } 

        #endregion

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposing)
            {
                if (disposing)
                {
                    /// dispose resources
                    this._connection.Dispose();
                    this._collection.Dispose();
                }
                this._disposing = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void SendAction(string action)
        {
            this._connection.WriteLine(action);
        }

        public void SendAction(JoinAction action)
        {
            this._connection.WriteLine(action.ToString());
        }

        public void SendAction(LeaveAction action)
        {
            this._connection.WriteLine(action.ToString());
        }

        public void SendAction(SendMessageAction action)
        {
            this._connection.WriteLine(action.ToString());
        }
    }
}
