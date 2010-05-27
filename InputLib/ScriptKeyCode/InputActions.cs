using System;
using System.Collections.Generic;

using System.Text;

namespace ScriptKeyCode
{
    /// <summary>
    /// Specifies the type of action taken with input.
    /// </summary>
    public enum InputActions
    {
        /// <summary>
        /// input was down and is now up.
        /// </summary>
        Press,
        /// <summary>
        /// Input is down
        /// </summary>
        Down,
        /// <summary>
        /// Input is up
        /// </summary>
        Up,
    }

}
