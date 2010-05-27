using System;
using System.Collections.Generic;

using System.Text;
using API;
namespace ScriptKeyCode
{
    /// <summary>
    /// A general trigger data class that provides event data to invoke the correct code at runtime.
    /// </summary>
    public class GeneralTrigger
    {
        /// <summary>
        /// Occurs when the trigger matches its input.
        /// </summary>
        public event TriggerFiredHandler EventFired;

        #region Fields
        private EventTypes eventtype;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralTrigger"/> class.
        /// </summary>
        /// <param name="EventType">Type of the event.</param>
        protected GeneralTrigger(EventTypes EventType)
        {
            eventtype = EventType;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the type of the event.
        /// </summary>
        /// <value>The type of the event.</value>
        public EventTypes EventType
        {
            get
            {
                return eventtype;
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Called when the event is triggered.
        /// </summary>
        /// <param name="TriggerType">Type of the trigger.</param>
        /// <param name="Trigger">The trigger.</param>
        protected virtual void OnEventTriggered(EventTypes TriggerType, GeneralTrigger Trigger)
        {
            if (EventFired != null)
                EventFired.Invoke(TriggerType, Trigger);
        }
        #endregion
    }

    /// <summary>
    /// A handler for events that are trigger 
    /// </summary>
    public delegate void TriggerFiredHandler(EventTypes EventType, GeneralTrigger Trigger);
}
