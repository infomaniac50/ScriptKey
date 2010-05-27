using System;
using System.Collections.Generic;

using System.Text;

namespace ScriptKeyCode
{
    /// <summary>
    /// Specifies the status of macro code compilation.
    /// </summary>
    public enum CompilerStatus
    {
        /// <summary>
        /// A program terminating error
        /// </summary>
        AppError,
        /// <summary>
        /// A compilation error
        /// </summary>
        Error,
        /// <summary>
        /// A compilation warning
        /// </summary>
        Warning,
        /// <summary>
        /// A compilation success
        /// </summary>
        Success
    }
}
