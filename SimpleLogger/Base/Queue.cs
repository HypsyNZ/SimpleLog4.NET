using System;
using System.Collections.Concurrent;
using System.IO;

namespace SimpleLogger.Base
{
    internal class Queue
    {
        private bool Running = false;
        private Message result;

        /// <summary>
        /// Processes the current Queue of messages
        /// </summary>
        /// <param name="loggedMessages">The Concurrent Queue of logged messages for this logger</param>
        /// <param name="path">The path to this loggers log file</param>
        /// <param name="logToConsole">True if this loggers messages should also be logged to the console</param>
        /// <param name="loglevel">The Log Level for the logger being processed</param>
        public void ProcessQueue(ConcurrentQueue<Message> loggedMessages, string path, bool logToConsole, LogLevel loglevel)
        {
            if (Running) { return; }
            try
            {
                Running = true;

                if (loggedMessages.Count > 0)
                {
                    bool message = loggedMessages.TryDequeue(out result);

                    if (result == null || message == false)
                    {
                        return;
                    }

                    if ((int)result.Level >= (int)loglevel)
                    {
                        File.AppendAllText(path, result.Content + "\n");

                        if (logToConsole) { Console.WriteLine(result.Content); }
                    }
                }
            }
            catch { }
            finally
            {
                Running = false;
            }
        }
    }
}