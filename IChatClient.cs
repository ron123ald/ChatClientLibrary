namespace ChatClientLibrary
{
    using System;
    using ChatClientLibrary.Chat.Action;
    using ChatClientLibrary.Chat.Events;
    
    public delegate void NewUserEventHandler(object sender, NewUserEventArgs e);
    public delegate void NewMessageEventHandler(object sender, NewMessageEventArgs e);
    public delegate void LogEventHandler(object sender, LogEventArgs e);
    public delegate void UserLeaveEventHandler(object sender, LeaveEventArgs e);

    public interface IChatClient : IDisposable
    {
        event NewMessageEventHandler NewMessageEvent;
        event NewUserEventHandler NewUserEvent;
        event LogEventHandler LogEvent;
        event UserLeaveEventHandler UserLeaveEvent;

        void SendAction(string action);
        void SendAction(JoinAction action);
        void SendAction(LeaveAction action);
        void SendAction(SendMessageAction action);

    }
}
