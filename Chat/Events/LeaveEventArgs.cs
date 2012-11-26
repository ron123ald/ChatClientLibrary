namespace ChatClientLibrary.Chat.Events
{
    using ChatClientLibrary.Chat.ChatUser;

    public class LeaveEventArgs
    {
        private string _userUniqueID = string.Empty;
        private User _user = default(User);

        public LeaveEventArgs(string username, string userUniqueID)
        {
            this.User = new User(username, userUniqueID);
        }

        public User User
        {
            get { return this._user; }
            set { this._user = value; }
        }
    }
}
