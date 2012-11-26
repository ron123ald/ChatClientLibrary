namespace ChatClientLibrary.Chat.Action
{
    using System;
    using Newtonsoft.Json;

    public class JoinAction : ChatAction
    {
        private string _dateTime = string.Empty;
        private string _userUniqueID = string.Empty;
        private string _userName = string.Empty;

        public JoinAction()
        {
            this._dateTime = DateTime.Now.ToString();
        }

        public JoinAction(string username, string userUniqueID)
        {
            this.Username = username;
            this.UserUniqueID = userUniqueID;
            this.CreateDate = DateTime.Now.ToString();
        }

        public JoinAction(string username, string userUniqueID, DateTime createDate)
        {
            this.Username = username;
            this.UserUniqueID = userUniqueID;
            this.CreateDate = createDate.ToString();
        }

        public JoinAction(string username, string userUniqueID, string createDate)
        {
            this.Username = username;
            this.UserUniqueID = userUniqueID;
            this.CreateDate = createDate;
        }


        public override string Action
        {
            get { return "join"; }
        }

        public string Username
        {
            get { return this._userName; }
            set { this._userName = value; }
        }

        public override string UserUniqueID
        {
            get { return this._userUniqueID; }
            set { this._userUniqueID = value; }
        }

        public string CreateDate
        {
            get { return this._dateTime.ToString(); }
            set { this._dateTime = value; }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
