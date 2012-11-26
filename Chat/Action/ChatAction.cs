namespace ChatClientLibrary.Chat.Action
{
    public abstract class ChatAction
    {
        public abstract string Action { get; }

        public abstract string UserUniqueID { get; set; }
    }
}
