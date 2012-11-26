namespace ChatClientLibrary.Chat.Events
{
    using System;
    using ChatClientLibrary.Chat.ChatUser;

    public class NewUserEventArgs : EventArgs
    {
        private User _user = default(User);
        
        public NewUserEventArgs(string username, string userUniqueID)
        {
            this._user = new User(username, userUniqueID);
        }

        public User User
        {
            get { return this._user; }
        }
    }
}
