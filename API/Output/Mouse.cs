﻿using System;
using System.Collections.Generic;

using System.Text;
using MouseKeyboardLibrary;
using System.Windows.Forms;
using ScriptKeyCode;
namespace API.Output
{
    /// <summary>
    /// Provides methods to send simulated input to the OS.
    /// </summary>
    public static class Mouse
    {
        #region Fields
        private const int delta = 120;
        #endregion



        #region Methods
        /// <summary>
        /// Sends a mouse event to the OS.
        /// </summary>
        /// <param name="Button">The button.</param>
        public static void SendButton(MouseButtons Button)
        {
            SendButton(Button, InputActions.Press);
        }

        /// <summary>
        /// Sends a mouse event to the OS.
        /// </summary>
        /// <param name="Button">The button.</param>
        /// <param name="Action">The action.</param>
        public static void SendButton(MouseButtons Button, InputActions Action)
        {
            switch (Action)
            {
                case InputActions.Press:
                    MouseSimulator.Click(Button);
                    break;
                case InputActions.Down:
                    MouseSimulator.MouseDown(Button);
                    break;
                case InputActions.Up:
                    MouseSimulator.MouseUp(Button);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sends a mouse wheel event to the OS.
        /// </summary>
        /// <param name="Direction">The direction to turn the wheel.</param>
        public static void SendWheel(WheelActions Direction)
        {
            SendWheel(Direction, 1);
        }

        /// <summary>
        /// Sends a mouse wheel event to the OS.
        /// </summary>
        /// <param name="Direction">The direction to turn the wheel.</param>
        /// <param name="NumberOfRolls">The number of times to roll the wheel.</param>
        public static void SendWheel(WheelActions Direction, int NumberOfRolls)
        {
            if (NumberOfRolls <= 0)
                throw new ArgumentException("The number of rolls must be greater than zero", "NumberOfRolls");

            //get the default value
            int deltatosend = delta;
            //multiply by how many times we want to roll the wheel
            deltatosend *= (int)NumberOfRolls;

            //specify the direction to roll the wheel
            deltatosend *= (Direction == WheelActions.Up ? 1 : -1);

            //roll the wheel
            MouseSimulator.MouseWheel(deltatosend);
        }
        #endregion
    }
}

