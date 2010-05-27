using System;
using System.Collections.Generic;
using System.Text;

namespace ScriptKeyCode
{
    /// <summary>
    /// An exception that specifies missing key event data.
    /// </summary>
    public class MissingKeyDataException : MalformedEventDataException
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MissingKeyDataException"/> class.
        /// </summary>
        /// <param name="EventData">The event data.</param>
        public MissingKeyDataException(string EventData)
            : base(EventData, "The key data is missing.") { } 
        #endregion
    }
}
