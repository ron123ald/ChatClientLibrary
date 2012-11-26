namespace ChatClientLibrary.Chat.Events
{
    using System;

    public class LogEventArgs : EventArgs
    {
        private ConsoleColor _color = default(ConsoleColor);
        private string _message = string.Empty;

        public LogEventArgs()
        {

        }

        public LogEventArgs(string message)
        {
            this.Message = message;
            this.Color = ConsoleColor.Green;
        }

        public LogEventArgs(string message, ConsoleColor color)
        {
            this.Color = color;
            this.Message = message;
        }

        public ConsoleColor Color
        {
            get { return this._color; }
            set { this._color = value; }
        }

        public string Message
        {
            get { return this._message; }
            set { this._message = value; }
        }
    }
}
