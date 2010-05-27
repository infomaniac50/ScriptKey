using System;
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
        public static class Keyboard
        {
            /// <summary>
            /// Sends a string to the OS.
            /// </summary>
            /// <param name="StringToSend">The string to send.</param>
            public static void SendString(string StringToSend)
            {
                char[] characters = StringToSend.ToCharArray();
                foreach (char character in characters)
                    SendCharacter(character);
            }

            /// <summary>
            /// Sends a character to the OS.
            /// </summary>
            /// <param name="CharToSend">The char to send.</param>
            public static void SendCharacter(char CharToSend)
            {
                Keys key;

                try
                {
                    key = (Keys)Enum.Parse(typeof(Keys), CharToSend.ToString(), true);
                    SendKey(key);
                }
                catch (ArgumentNullException ex)
                {
                                        
                }
                catch (ArgumentException ex)
                {

                }
            }


            /// <summary>
            /// Sends a keyboard event to the OS.
            /// </summary>
            /// <param name="Key">The key.</param>
            public static void SendKey(Keys Key)
            {
                SendKey(Key, InputActions.Press);
            }

            /// <summary>
            /// Sends a keyboard event to the OS.
            /// </summary>
            /// <param name="Key">The key.</param>
            /// <param name="Action">The action.</param>
            public static void SendKey(Keys Key, InputActions Action)
            {
                switch (Action)
                {
                    case InputActions.Press:
                        KeyboardSimulator.KeyPress(Key);
                        break;
                    case InputActions.Down:
                        KeyboardSimulator.KeyDown(Key);
                        break;
                    case InputActions.Up:
                        KeyboardSimulator.KeyUp(Key);
                        break;
                    default:
                        break;
                }
            }

            
        } 
    }

