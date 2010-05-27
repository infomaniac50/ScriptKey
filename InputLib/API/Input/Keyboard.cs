using System;
using System.Collections.Generic;

using System.Text;
using MouseKeyboardLibrary;
using System.Windows.Forms;
namespace API
{
    /// <summary>
    /// Provide a way to gather input from the keyboard.
    /// </summary>
    namespace Input
    {
        public static class Keyboard
        {
            #region Constructors
            static Keyboard()
            {
                Hook = new KeyboardHook();
                Hook.Start();
                Application.ApplicationExit += new EventHandler(OnApplicationExit);
                AppDomain.CurrentDomain.DomainUnload += new EventHandler(OnDomainUnload);
            }
            #endregion

            #region Properties
            internal static KeyboardHook Hook
            {
                get;
                private set;
            }
            #endregion

            #region Methods
            static void OnApplicationExit(object sender, EventArgs e)
            {
                Hook.Stop();
            }

            static void OnDomainUnload(object sender, EventArgs e)
            {
                Hook.Stop();
            }
            #endregion
        } 
    }
}
