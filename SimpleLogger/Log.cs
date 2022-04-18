using SimpleLogger.Base;
using System.Collections.Concurrent;
using System.Threading;

namespace SimpleLogger
{
    public partial class Log
    {
        private Timer LogTimer;
        private readonly string LogPath = string.Empty;
        private readonly int LoggingInterval = 100;
        private readonly Queue MessageQueue = new Queue();
        private readonly ConcurrentQueue<Message> LoggedMessages = new ConcurrentQueue<Message>();
        private bool TimerRunning = false;

        /// <summary>
        /// The Log Level for this Logger
        /// <para>Default: LogLevel.Error</para>
        /// </summary>
        public LogLevel LogLevel { get; set; }

        /// <summary>
        /// True if this Logger should also Log messages to the Console
        /// <para>Optional</para>
        /// <para>Default: false</para>
        /// </summary>
        public bool LogToConsole { get; set; }

        /// <summary>
        /// The Date Format for messages used by this Logger
        /// <para>Optional</para>
        /// <para>Default: "MM/dd/yy HH:mm:ss:fff"</para>
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// A Simple Logger
        /// </summary>
        /// <param name="path">Where to save the Log file</param>
        /// <param name="logToConsole">True if the message should also be logged to the console</param>
        /// <param name="dateFormat">The Date Format for messages used by this Logger</param>
        /// <param name="logLevel">The Log Level for this Logger</param>
        /// <param name="loggingInterval">How often the Logger should check for messages to write to the log</param>
        public Log(string path, bool logToConsole = false, string dateFormat = "MM/dd/yy HH:mm:ss:fff", LogLevel logLevel = LogLevel.Error, int loggingInterval = 100)
        {
            LoggingInterval = loggingInterval;
            LogLevel = logLevel;
            DateFormat = dateFormat;
            LogPath = path;
            LogToConsole = logToConsole;
        }

        /// <summary>
        /// Write a Message to the Log
        /// </summary>
        /// <param name="message">The Message</param>
        /// <param name="logLevel">The Log Level of the Message</param>
        public void Write(string message, LogLevel logLevel = LogLevel.Error)
        {
            try
            {
                LoggedMessages.Enqueue(new Message(message, DateFormat, logLevel));

                MessageQueue.ProcessQueue(LoggedMessages, LogPath, LogToConsole, LogLevel);

                if (!TimerRunning)
                {
                    TimerRunning = true;
                    LogTimer = new Timer(new TimerCallback((o) =>
                    {
                        MessageQueue.ProcessQueue(LoggedMessages, LogPath, LogToConsole, LogLevel);
                    }), null, 1, LoggingInterval);
                }
            }
            catch { }
        }

        /// <summary>
        /// Dispose the LogTimer and release all resources for this Log
        /// </summary>
        public void Dispose()
        {
            LogTimer?.Dispose();
            this?.Dispose();
        }
    }
}