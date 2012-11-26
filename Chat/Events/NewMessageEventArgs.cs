namespace ChatClientLibrary.Chat.Events
{
    using System;
    using ChatClientLibrary.Chat.ChatUser;

    public class NewMessageEventArgs : EventArgs
    {
        private string _message = string.Empty;
        private string _from = string.Empty;
        private User _senderDetails = default(User);

        public NewMessageEventArgs()
        {

        }

        public NewMessageEventArgs(string from, string message)
        {
            this.Message = message;
            this.From = from;
            /// get user base from "from"
            
        }

        public User Sender
        {
            get { return this._senderDetails; }
            set { this._senderDetails = value; }
        }

        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        public string From 
        {
            get { return this._from; }
            set { this._from = value; }
        }
    }
}