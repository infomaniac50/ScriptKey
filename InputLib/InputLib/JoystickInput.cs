using System;
using System.Collections.Generic;
using Soopah.Xna.Input;
using System.Windows.Forms;
namespace InputLib
{
    /// <summary>
    /// Provides access to a joytick.
    /// </summary>
    public static class JoystickInput
    {
        #region Fields
        private static List<DirectInputGamepad> joysticks; 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes the <see cref="JoystickInput"/> class.
        /// </summary>
        static JoystickInput()
        {
            joysticks = DirectInputGamepad.Gamepads;
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Gets the joystick.
        /// </summary>
        /// <value>The joystick.</value>
        public static DirectInputGamepad Hook
        {
            get
            {
                if (IsJoystickConnected)
                    return joysticks[0];
                else
                    return null;
            }
        }

        /// <summary>
        /// Gets a value indicating whether a joystick is connected.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this a joystick is connected; otherwise, <c>false</c>.
        /// </value>
        public static bool IsJoystickConnected
        {
            get
            {
                return joysticks.Count > 0;
            }
        } 
        #endregion
    }
}
