using System;
using System.Collections.Generic;

using System.Text;
using API;
namespace ScriptKeyCode
{
    /// <summary>
    /// An event type that specifies user input.
    /// </summary>
    public class InputTrigger : GeneralTrigger
    {
        #region Fields
        private bool shouldhandle;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="InputTrigger"/> class.
        /// </summary>
        /// <param name="EventType">Type of the event.</param>
        /// <param name="ShouldHandle">if set to <c>true</c> trigger should handle the event.</param>
        protected InputTrigger(EventTypes EventType,bool ShouldHandle)
            : base(EventType)
        {
            shouldhandle = ShouldHandle;
        }         
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether the trigger should handle the event.
        /// </summary>
        /// <value><c>true</c> if the trigger should handle the event; otherwise, <c>false</c>.</value>
        public bool ShouldHandle
        {
            get
            {
                return shouldhandle;
            }
        }
        #endregion
    }
}
