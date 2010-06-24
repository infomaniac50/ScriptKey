using System;
using System.Text;
using System.Reflection;
using System.IO;
using System.Windows.Forms;
namespace DerekChafin.Logging
{
    /// <summary>
    /// Writes messages to a log file.
    /// </summary>
    public static class LogWriter
    {
        #region Constructors
        static LogWriter()
        {
            BaseDirectory = Application.LocalUserAppDataPath;
            FileName = "Application.log";
        }


        #endregion

        #region Methods
        /// <summary>
        /// Clears the log.
        /// </summary>
        public static void ClearLog()
        {
            if (File.Exists(FilePath))
                File.Delete(FilePath);
        }

        /// <summary>
        /// Writes a message to the log.
        /// </summary>
        /// <param name="Message">The message.</param>
        public static void WriteEntry(string Message)
        {
            WriteEntry(Message, false);
        }

        /// <summary>
        /// Writes an entry to the log.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <param name="ReportTime">if set to <c>true</c> report the time and date.</param>
        public static void WriteEntry(string Message, bool ReportTime)
        {
            WriteEntry(Message, ReportTime, TraceEventType.Information);
        }

        /// <summary>
        /// Writes an entry to the log.
        /// </summary>
        /// <param name="Message">The message.</param>
        /// <param name="ReportTime">if set to <c>true</c> report the time and date.</param>
        /// <param name="Severity">The severity.</param>
        public static void WriteEntry(string Message, bool ReportTime, TraceEventType Severity)
        {
            //if ReportTime is true then add a DateTime string to the message.
            if (ReportTime)
                Message = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt") + "  " + Message;

            //write the message to the log file.
            File.AppendAllText(FilePath, Severity.ToString() + "  " + Message);
        }
        #endregion


        #region Properties
        /// <summary>
        /// Gets the log path.
        /// </summary>
        /// <value>The log path.</value>
        public static string FilePath
        {
            get
            {
                return Path.Combine(BaseDirectory, FileName);
            }
        }

        /// <summary>
        /// Gets or sets the name of the log file.
        /// </summary>
        /// <value>The name of the log file.</value>
        public static string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the base directory.
        /// </summary>
        /// <value>The base directory.</value>
        public static string BaseDirectory
        {
            get;
            set;
        }
        #endregion
    }
}
