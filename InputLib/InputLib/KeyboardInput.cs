using System;
using System.Collections.Generic;

using System.Text;
using MouseKeyboardLibrary;
using System.Windows.Forms;
namespace InputLib
{
    /// <summary>
    /// Provide a way to gather input from the keyboard.
    /// </summary>
    public static class KeyboardInput
    {
        #region Fields
        private static KeyboardHook keyboard = new KeyboardHook(); 
        #endregion

        #region Constructors
        static KeyboardInput()
        {
            keyboard.Start();
            Application.ApplicationExit += new EventHandler(OnApplicationExit);
            AppDomain.CurrentDomain.DomainUnload +=new EventHandler(OnDomainUnload);
        }
        #endregion

        #region Properties
        internal static KeyboardHook Hook
        {
            get
            {
                return keyboard;
            }
        } 
        #endregion

        #region Methods
        static void OnApplicationExit(object sender, EventArgs e)
        {
            keyboard.Stop();
        }

        static void OnDomainUnload(object sender, EventArgs e)
        {
            keyboard.Stop();
        }  
        #endregion
    }
}
