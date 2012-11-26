namespace ChatClientLibrary.Chat.Utility
{
    using ChatClientLibrary.Chat.Events;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public static class ChatUtility
    {
        public static ChatActionTypes GetActionType(this string dataRecieved)
        {
            ChatActionTypes type = default(ChatActionTypes);
            JObject actionDetails = JsonConvert.DeserializeObject<JObject>(dataRecieved);
            if (actionDetails != null)
            {
                switch ((string)actionDetails["Action"])
                {
                    case "join":
                        type = ChatActionTypes.join;
                        break;
                    case "send":
                        type = ChatActionTypes.send;
                        break;
                    case "leave":
                        type = ChatActionTypes.leave;
                        break;
                    case "newmessage":
                        type = ChatActionTypes.newmessage;
                        break;
                    case "newuser":
                        type = ChatActionTypes.newuser;
                        break;
                    default: break;
                }
            }
            return type;
        }

        public static NewMessageEventArgs ProcessNewMessage(this string dataRecieved)
        {
            NewMessageEventArgs e = default(NewMessageEventArgs);
            try
            {
                e = JsonConvert.DeserializeObject<NewMessageEventArgs>(dataRecieved);
            }
            catch { }
            return e;
        }

        public static NewUserEventArgs ProcessNewUser(this string dataRecieved)
        {
            NewUserEventArgs e = default(NewUserEventArgs);
            try
            {
                JObject data = JsonConvert.DeserializeObject<JObject>(dataRecieved);
                if (data != null)
                    e = new NewUserEventArgs((string)data["Username"], (string)data["UserUniqueID"]);
            }
            catch { }
            return e;
        }

        public static LeaveEventArgs ProcessUserLeave(this string dataRecieved)
        {
            LeaveEventArgs e = default(LeaveEventArgs);
            try
            {
                e = JsonConvert.DeserializeObject<LeaveEventArgs>(dataRecieved);
            }
            catch { }
            return e;
        }
    }
}
