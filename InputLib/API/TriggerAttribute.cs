using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using ScriptKeyCode;
namespace API
{
    /// <summary>
    /// An attribute that specifies event data that connects a method to input events.
    /// </summary>
    [AttributeUsage(AttributeTargets.Method)]
    public class TriggerAttribute : Attribute
    {
        #region Fields
        private GeneralTrigger eventdata; 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TriggerAttribute"/> class.
        /// </summary>
        /// <param name="Key">The key.</param>
        /// <param name="Action">The action.</param>
        public TriggerAttribute(Keys Key, InputActions Action)
        {
            eventdata = new KeyboardTrigger(Key, Action);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TriggerAttribute"/> class.
        /// </summary>
        /// <param name="Button">The button.</param>
        /// <param name="Action">The action.</param>
        public TriggerAttribute(MouseButtons Button, InputActions Action)
        {
            eventdata = new MouseButtonTrigger(Button, Action);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TriggerAttribute"/> class.
        /// </summary>
        /// <param name="Action">The action.</param>
        public TriggerAttribute(WheelActions Action)
        {
            eventdata = new MouseWheelTrigger(Action);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TriggerAttribute"/> class.
        /// </summary>
        /// <param name="TimerInterval">The timer interval.</param>
        public TriggerAttribute(int TimerInterval)
        {
            eventdata = new TimerTrigger(TimerInterval);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the event data.
        /// </summary>
        /// <value>The event data.</value>
        public GeneralTrigger EventData
        {
            get
            {
                return eventdata;
            }
        } 
        #endregion
    }
}
