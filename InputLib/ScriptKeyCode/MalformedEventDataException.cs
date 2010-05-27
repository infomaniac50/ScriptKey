using System;
using System.Collections.Generic;

using System.Text;

namespace ScriptKeyCode
{
    /// <summary>
    /// An exception that contains malformed event data
    /// </summary>
    public class MalformedEventDataException : Exception
    {
        #region Fields
        private string eventdata;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MalformedEventDataException"/> class.
        /// </summary>
        /// <param name="EventData">The event data.</param>
        public MalformedEventDataException(string EventData)
            : this(EventData,"The event data " + EventData + " is not in the correct format.") { }

        /// <summary>
        /// Initializes a new instance of the <see cref="MalformedEventDataException"/> class.
        /// </summary>
        /// <param name="EventData">The event data.</param>
        /// <param name="Message">The message.</param>
        public MalformedEventDataException(string EventData, string Message)
            : base(Message)
        {
            eventdata = EventData;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the event data.
        /// </summary>
        /// <value>The event data.</value>
        public string EventData
        {
            get
            {
                return eventdata;
            }
        }
        #endregion
    }
}
