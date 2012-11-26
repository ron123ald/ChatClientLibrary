namespace ChatClientLibrary.Chat.ChatUser
{
    public class User
    {
        private string _username = string.Empty;
        private string _userUniqueID = string.Empty;
        
        public User()
        {

        }

        public User(string username, string userUniqueID)
        {
            this.Username = username;
            this.UserUnqiueID = userUniqueID;
        }


        public string Username 
        {
            get { return this._username; }
            set { this._username = value; } 
        }

        public string UserUnqiueID 
        {
            get { return this._userUniqueID; }
            set { this._userUniqueID = value; }
        }
    }
}
