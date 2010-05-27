using System;
using System.Collections.Generic;

using System.Text;

namespace API
{

    /// <summary>
    /// Define event types for triggers
    /// </summary>
    public enum EventTypes
    {
        /// <summary>
        /// Specifies a keyboard event
        /// </summary>
        Keyboard,
        /// <summary>
        /// Specifies a mouse button event
        /// </summary>
        MouseButton,
        /// <summary>
        /// Specifies a mouse wheel event
        /// </summary>
        MouseWheel,
        /// <summary>
        /// Specifies a timer event
        /// </summary>
        Timer,
    }
}
