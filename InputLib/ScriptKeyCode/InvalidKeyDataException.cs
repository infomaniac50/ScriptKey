using System;
using System.Collections.Generic;

using System.Text;

namespace ScriptKeyCode
{
    /// <summary>
    /// An exception that contains invalid key data.
    /// </summary>
    public class InvalidKeyDataException : MalformedEventDataException
    {
        #region Fields
        private string key; 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidKeyDataException"/> class.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <param name="EventData">The event data.</param>
        public InvalidKeyDataException(string Key, string EventData)
            : this(Key, EventData, "The string " + Key + " is not a valid key.")     {  }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidKeyDataException"/> class.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <param name="EventData">The event data.</param>
        /// <param name="Message">The message.</param>
        public InvalidKeyDataException(string Key,string EventData,string Message)
            :base(EventData,Message)
        {
            key = Key;
        }
        
        #endregion

        #region Properties
        /// <summary>
        /// Gets the invalid key.
        /// </summary>
        /// <value>The invalid key.</value>
        public string Key
        {
            get
            {
                return key;
            }
        }

        #endregion
    }
}
