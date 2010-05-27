using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using API;
using Utility;
namespace ScriptKeyCode
{
    /// <summary>
    /// An event type that specifies keyboard input.
    /// </summary>
    public class KeyboardTrigger : InputTrigger
    {
        #region Fields
        private InputActions action;
        private Keys key;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardTrigger"/> class.
        /// </summary>
        /// <param name="KeyData">The key data.</param>
        /// <param name="Action">The action.</param>
        /// <param name="ShouldHandle">if set to <c>true</c> the trigger should handle the event.</param>
        public KeyboardTrigger(Keys KeyData, InputActions Action, bool ShouldHandle)
            : base(EventTypes.Keyboard, ShouldHandle)
        {
            action = Action;
            key = KeyData;
            //InputLib.KeyboardInput.Hook.KeyPress += new KeyPressEventHandler(OnKeyPress);
            InputLib.KeyboardInput.Hook.KeyDown += new KeyEventHandler(OnKeyDown);
            InputLib.KeyboardInput.Hook.KeyUp += new KeyEventHandler(OnKeyUp);            
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardTrigger"/> class.
        /// </summary>
        /// <param name="KeyData">The key data.</param>
        /// <param name="Action">The action.</param>
        public KeyboardTrigger(Keys KeyData, InputActions Action) : this(KeyData, Action, true) { }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the key value.
        /// </summary>
        /// <value>The key value.</value>
        public int KeyValue
        {
            get
            {
                return (((int)key) & 0xffff);
            }
        }

        /// <summary>
        /// Gets the key data.
        /// </summary>
        /// <value>The key data.</value>
        public Keys KeyData
        {
            get
            {
                return key;
            }
        }

        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <value>The action.</value>
        public InputActions Action
        {
            get
            {
                return action;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Shift key is pressed.
        /// </summary>
        /// <value><c>true</c> if shift key is pressed; otherwise, <c>false</c>.</value>
        public bool Shift
        {
            get
            {
                return ((key & Keys.Shift) == Keys.Shift);
            }
        }

        /// <summary>
        /// Gets a value indicating whether Alt key is pressed.
        /// </summary>
        /// <value><c>true</c> if the Alt key is pressed; otherwise, <c>false</c>.</value>
        public bool Alt
        {
            get
            {
                return ((key & Keys.Alt) == Keys.Alt);
            }
        }

        /// <summary>
        /// Gets a value indicating whether the Control key is pressed.
        /// </summary>
        /// <value><c>true</c> if Control key is pressed; otherwise, <c>false</c>.</value>
        public bool Control
        {
            get
            {
                return ((key & Keys.Control) == Keys.Control);
            }
        }

        /// <summary>
        /// Gets the key char.
        /// </summary>
        /// <value>The key char.</value>
        public char KeyChar
        {
            get
            {
                return (char)KeyValue;
            }
        }
        #endregion

        #region Methods
        #region EventHandlerMethods
        private void FireEvent()
        {
            base.OnEventTriggered(EventTypes.Keyboard, this);
        }

        private void OnKeyPress(object sender, KeyEventArgs e)
        {
            if (action == InputActions.Press && e.KeyData == this.KeyData)
            {
                e.Handled = ShouldHandle;
                FireEvent();
            }
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (action == InputActions.Up && e.KeyData == this.KeyData)
            {
                e.Handled = ShouldHandle;
                FireEvent();
            }
            OnKeyPress(sender, e);
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (action == InputActions.Down && e.KeyData == this.KeyData)
            {
                e.Handled = ShouldHandle;
                FireEvent();
            }
        }
        #endregion

        ///// <summary>
        ///// Parses the specified event data.
        ///// </summary>
        ///// <param name="EventData">The event data.</param>
        ///// <returns>A keyboard trigger that contains the event data.</returns>
        //public static KeyboardTrigger Parse(string EventData)
        //{
        //    string[] keywords = EventDataParser.GetKeys(EventData);
        //    InputActions action = EventDataParser.GetInputAction(EventData);



        //    Keys keys = Keys.None;
        //    string betterkeyword;
        //    foreach (string keyword in keywords)
        //    {
        //        betterkeyword = Formatting.CapitalizeString(keyword.ToLower());

        //        if (System.Enum.IsDefined(typeof(Keys), betterkeyword))
        //            keys |= (Keys)System.Enum.Parse(typeof(Keys), betterkeyword);
        //        else
        //            throw new InvalidKeyDataException(betterkeyword, EventData);
        //    }


        //    KeyboardTrigger trigger = new KeyboardTrigger(keys, action);

        //    return trigger;
        //}

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {            
            KeysConverter converter = new KeysConverter();
            return converter.ConvertToString(key) + " " + this.action.ToString();
        }
        #endregion
    }
}
