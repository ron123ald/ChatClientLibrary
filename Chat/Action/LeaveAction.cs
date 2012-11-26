namespace ChatClientLibrary.Chat.Action
{
    using Newtonsoft.Json;

    public class LeaveAction : ChatAction
    {
        private string _userUniqueID = string.Empty;

        public LeaveAction()
        {

        }

        public LeaveAction(string userUniqueID)
        {
            this.UserUniqueID = userUniqueID;
        }

        public override string Action
        {
            get { return "leave"; }
        }

        public override string UserUniqueID
        {
            get { return this._userUniqueID; }
            set { this._userUniqueID = value; }
        }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
