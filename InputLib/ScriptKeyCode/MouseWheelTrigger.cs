using System;
using System.Collections.Generic;

using System.Text;
using System.Windows.Forms;
using MouseKeyboardLibrary;
using API;
namespace ScriptKeyCode
{
    /// <summary>
    /// An event type that specifies mouse wheel input. 
    /// </summary>
    public class MouseWheelTrigger : InputTrigger
    {
        #region Fields
        private WheelActions action;
        #endregion
        
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MouseWheelTrigger"/> class.
        /// </summary>
        /// <param name="Action">The action.</param>
        /// <param name="ShouldHandle">if set to <c>true</c> the trigger should handle the event.</param>
        public MouseWheelTrigger(WheelActions Action,bool ShouldHandle) : base(EventTypes.MouseWheel, ShouldHandle)
        {
            action = Action;
            InputLib.MouseInput.Hook.MouseWheel += new MouseEventHandler(OnMouseWheel);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseWheelTrigger"/> class.
        /// </summary>
        /// <param name="Action">The action.</param>
        public MouseWheelTrigger(WheelActions Action) : this(Action, true) { }
        #endregion

        #region Properties
        
        /// <summary>
        /// Gets the direction the mouse wheel was turned.
        /// </summary>
        /// <value>The direction the mouse wheel was turned.</value>
        public WheelActions Direction
        {
            get
            {
                return action;
            }
        }    

        #endregion     

        #region Methods
        void OnMouseWheel(object sender, MouseEventArgs e)
        {
            WheelActions inputaction = e.Delta > 0 ? WheelActions.Up : WheelActions.Down;

            if (inputaction == action)
                base.OnEventTriggered(EventTypes.MouseWheel, this);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Mouse wheel " + this.Direction.ToString().ToLower();
        }

        ///// <summary>
        ///// Parses the specified event data.
        ///// </summary>
        ///// <param name="EventData">The event data.</param>
        ///// <returns></returns>
        //public static MouseWheelTrigger Parse(string EventData)
        //{
        //    WheelActions action = EventDataParser.GetWheelAction(EventData);
        //    return new MouseWheelTrigger(action);
        //} 
        #endregion
    }
}
