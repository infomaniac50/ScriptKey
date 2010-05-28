using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using API;
using API.Input;
using Utility;
namespace ScriptKeyCode
{
    /// <summary>
    /// An event type that specifies mouse button input.
    /// </summary>
    public class MouseButtonTrigger : InputTrigger
    {
        #region Fields
        private InputActions action;
        private MouseButtons button;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MouseButtonTrigger"/> class.
        /// </summary>
        /// <param name="Button">The button.</param>
        /// <param name="Action">The action.</param>
        /// <param name="ShouldHandle">if set to <c>true</c> the trigger should handle the event.</param>
        public MouseButtonTrigger(MouseButtons Button, InputActions Action, bool ShouldHandle)
            : base(EventTypes.MouseButton, ShouldHandle)
        {
            button = Button;
            action = Action;
            Mouse.Hook.MouseDown += new MouseEventHandler(OnMouseDown);
            Mouse.Hook.MouseUp += new MouseEventHandler(OnMouseUp);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseButtonTrigger"/> class.
        /// </summary>
        /// <param name="Button">The button.</param>
        /// <param name="Action">The action.</param>
        public MouseButtonTrigger(MouseButtons Button, InputActions Action) : this(Button, Action, true) { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the button pressed.
        /// </summary>
        /// <value>The button pressed.</value>
        public MouseButtons Button
        {
            get
            {
                return button;
            }
        }

        /// <summary>
        /// Gets the button action.
        /// </summary>
        /// <value>The button action.</value>
        public InputActions Action
        {
            get
            {
                return action;
            }
        }
        #endregion

        #region Methods

        #region EventHandlerMethods
        void OnMousePress(object sender, MouseEventArgs e)
        {
            if (action == InputActions.Press && e.Button == this.button && e.Clicks == 1)
                base.OnEventTriggered(EventTypes.MouseButton, this);
        }

        void OnMouseUp(object sender, MouseEventArgs e)
        {
            if (action == InputActions.Up && e.Button == this.button)
                base.OnEventTriggered(EventTypes.MouseButton, this);

            OnMousePress(sender, e);
        }

        void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (action == InputActions.Down && e.Button == this.button)
                base.OnEventTriggered(EventTypes.MouseButton, this);
        }
        #endregion

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return this.Button.ToString() + " mouse button " + this.action.ToString().ToLower();
        }


        ///// <summary>
        ///// Parses the specified event data.
        ///// </summary>
        ///// <param name="EventData">The event data.</param>
        ///// <returns></returns>
        //public static MouseButtonTrigger Parse(string EventData)
        //{
        //    InputActions action = EventDataParser.GetInputAction(EventData);
        //    string buttonstring = EventDataParser.GetKeys(EventData)[0];
        //    MouseButtons button;
        //    buttonstring = buttonstring.Trim();
        //    buttonstring = Formatting.CapitalizeString(buttonstring);

        //    if (System.Enum.IsDefined(typeof(MouseButtons), buttonstring))
        //        button = (MouseButtons)System.Enum.Parse(typeof(MouseButtons), buttonstring);
        //    else
        //        throw new InvalidKeyDataException(buttonstring, EventData);

        //    return new MouseButtonTrigger(button, action);
        //}
        #endregion
    }

}
