namespace ChatClientLibrary.Chat
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Net;
    using System.Net.Sockets;
    using ChatClientLibrary.Chat.Factory;
    using ChatClientLibrary.Chat.Utility;

    public class ChatConnection : IDisposable
    {
        private TcpClient _client = default(TcpClient);
        private NetworkStream _networkStream = default(NetworkStream);
        private StreamReader _reader = default(StreamReader);
        private StreamWriter _writer = default(StreamWriter);
        private BackgroundWorker _backgroundWorker = default(BackgroundWorker);
        private static ChatConnection _instance = default(ChatConnection);

        public event LogEventHandler InternalLogEvent;
        public event NewMessageEventHandler InternalNewMessageEvent;
        public event NewUserEventHandler InternalNewUserEvent;
        public event UserLeaveEventHandler InternalUserLeaveEvent;

        public static ChatConnection InstanceContext
        {
            get { return _instance ?? (_instance = (new ChatConnection())); }
        }

        private ChatConnection()
        {
            this._backgroundWorker = new BackgroundWorker();
            this._backgroundWorker.DoWork += backgroundDoWork;
            this._backgroundWorker.RunWorkerCompleted += backgroundRunWorkerCompleted;
        }

        #region Background Worker
        
        private void backgroundRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void backgroundDoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (this.InternalLogEvent != null)
                    this.InternalLogEvent(this, new Events.LogEventArgs("Connecting..."));
                
                this._client = new TcpClient(((ChatFactory)e.Argument).Address, ((ChatFactory)e.Argument).Port);
                this._networkStream = this._client.GetStream();
                this._reader = new StreamReader(this._networkStream);
                this._writer = new StreamWriter(this._networkStream);

                if (this.InternalLogEvent != null)
                    this.InternalLogEvent(this, new Events.LogEventArgs("Connected to server"));
            }
            catch (SocketException ex)
            {
                if (this.InternalLogEvent != null)
                    this.InternalLogEvent(this, new Events.LogEventArgs(ex.Message));
                return;
            }

            while (true)
            {
                try
                {
                    string dataRecieved = string.Empty;
                
                        dataRecieved = this._reader.ReadLine();
                        if (!string.IsNullOrEmpty(dataRecieved))
                        {
                            switch (dataRecieved.GetActionType())
                            {
                                case ChatActionTypes.newmessage:
                                    /// new message comming
                                    this.InternalNewMessageEvent(this, dataRecieved.ProcessNewMessage());
                                    break;
                                case ChatActionTypes.newuser:
                                    /// new user 
                                    this.InternalNewUserEvent(this, dataRecieved.ProcessNewUser());
                                    break;
                                case ChatActionTypes.leave:
                                    /// user leave
                                    this.InternalUserLeaveEvent(this, dataRecieved.ProcessUserLeave());
                                    break;
                                default: break;
                            }
                        }
                }
                catch (Exception ex)
                {
                    this.InternalLogEvent(this, new Events.LogEventArgs(ex.Message, ConsoleColor.Red));
                }
            }
        } 

        #endregion

        public void SetConnection(ChatFactory factory)
        {
            this._backgroundWorker.RunWorkerAsync(factory);
        }

        public void WriteLine(string message)
        {
            this._writer.WriteLine(message);
            this._writer.Flush();
        }

        public string ReadLine()
        {
            return this._reader.ReadLine();
        }

        public void Dispose()
        {
            /// BackgroundWorker
            this._backgroundWorker.Dispose();
            /// TcpClient
            this._client.Close();
            /// NetworkStream
            this._networkStream.Close();
            this._networkStream.Dispose();
            /// StreamReader / StreamWriter
            this._reader.Close();
            this._reader.Dispose();

            this._writer.Close();
            this._writer.Dispose();
        }
    }
}
