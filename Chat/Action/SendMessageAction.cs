namespace ChatClientLibrary.Chat.Action
{
    using Newtonsoft.Json;

    public class SendMessageAction : ChatAction
    {
        private string _userUniqueID = string.Empty;
        private string _message = string.Empty;

        public SendMessageAction()
        {

        }

        public SendMessageAction(string userUniqueID, string message)
        {
            this.UserUniqueID = userUniqueID;
            this.Message = message;
        }

        public override string Action
        {
            get { return "send"; }
        }

        public override string UserUniqueID
        {
            get { return this._userUniqueID; }
            set { this._userUniqueID = value; }
        }

        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
