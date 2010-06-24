using System;
using System.Collections.Generic;
using System.Text;

namespace DerekChafin.Logging
{
    /// <summary>
    /// Denotes levels of severity for a log event.
    /// </summary>
    public enum TraceEventType
    {
        /// <summary>
        /// An unresolvable blocking error state.
        /// </summary>
        Critical,
        /// <summary>
        /// A resolvable blocking error state.
        /// </summary>
        Error,
        /// <summary>
        /// A non-error state.
        /// </summary>
        Information,
        /// <summary>
        /// A non-blocking error state.
        /// </summary>
        Warning
    }    
}
