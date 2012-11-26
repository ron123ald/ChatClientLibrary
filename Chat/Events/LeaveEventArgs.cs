namespace ChatClientLibrary.Chat.Events
{
    using ChatClientLibrary.Chat.ChatUser;

    public class LeaveEventArgs
    {
        private string _userUniqueID = string.Empty;

        public LeaveEventArgs()
        {

        }

        public LeaveEventArgs(string userUniqueID)
        {
            this.UserUniqueID = userUniqueID;
        }

        public string UserUniqueID
        {
            get { return this._userUniqueID; }
            set { this._userUniqueID = value; }
        }
    }
}
