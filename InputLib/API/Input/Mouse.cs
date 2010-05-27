using System;
using System.Collections.Generic;

using System.Text;
using MouseKeyboardLibrary;
using System.Drawing;
using System.Windows.Forms;
namespace API
{
    namespace Input
    {
        /// <summary>
        /// Provides a way to gather input from the mouse.
        /// </summary>
        public static class Mouse
        {
            #region Constructors
            static Mouse()
            {
                Hook = new MouseHook();
                Hook.Start();
                Application.ApplicationExit += new EventHandler(OnAppExit);
                AppDomain.CurrentDomain.DomainUnload += new EventHandler(OnDomainUnload);
            }
            #endregion

            #region Methods
            static void OnAppExit(object sender, EventArgs e)
            {
                Hook.Stop();
            }

            static void OnDomainUnload(object sender, EventArgs e)
            {
                Hook.Stop();
            }
            #endregion

            #region Properties
            /// <summary>
            /// Gets the mouse.
            /// </summary>
            /// <value>The mouse.</value>
            internal static MouseHook Hook
            {
                get;
                private set;
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

}
