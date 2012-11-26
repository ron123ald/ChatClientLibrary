namespace ChatClientLibrary.Chat.Events
{
    using System;
    using ChatClientLibrary.Chat.ChatUser;

    public class NewUserEventArgs : EventArgs
    {
        private string _username = string.Empty;
        private string _userUniqueID = string.Empty;
        private User _user = default(User);

        public NewUserEventArgs()
        {

        }

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
