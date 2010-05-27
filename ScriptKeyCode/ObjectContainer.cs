using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptKeyCode
{
    /// <summary>
    /// A holds messages to send to a remote object.
    /// </summary>
    [Serializable()]
    public struct ObjectMessage
    {

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>The message.</value>
        public object Message
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the type of the message.
        /// </summary>
        /// <value>The type of the message.</value>
        public string MessageType
        {
            get;
            set;
        }
    }
}
