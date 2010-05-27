using System;
using System.Collections.Generic;

using System.Text;
using MouseKeyboardLibrary;
using System.Drawing;
using System.Windows.Forms;
namespace InputLib
{
    /// <summary>
    /// Provides a way to gather input from the mouse.
    /// </summary>
    public static class MouseInput
    {
        #region Fields
        private static MouseHook mouse = new MouseHook();
        #endregion

        #region Constructors
        static MouseInput()
        {
            mouse.Start();
            Application.ApplicationExit += new EventHandler(OnAppExit);
            AppDomain.CurrentDomain.DomainUnload += new EventHandler(OnDomainUnload);
        }

 
        #endregion
        
        #region Methods
        static void OnAppExit(object sender, EventArgs e)
        {
            mouse.Stop();
        }

        static void OnDomainUnload(object sender, EventArgs e)
        {
            mouse.Stop();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the mouse.
        /// </summary>
        /// <value>The mouse.</value>
        internal static MouseHook Hook
        {
            get
            {
                return mouse;
            }
        }

        /// <summary>
        /// Gets the mouse location.
        /// </summary>
        /// <value>The mouse location.</value>
        public static Point Location
        {
            get
            {
                return Cursor.Position;
            }
        } 
        #endregion
    }
}
