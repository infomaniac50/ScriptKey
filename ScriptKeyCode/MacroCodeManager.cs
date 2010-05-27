using System;
using System.Collections.Generic;
using System.Text;
using API;

namespace ScriptKeyCode
{
    /// <summary>
    /// Manages access to macro code items.
    /// </summary>
    public class MacroCodeManager
    {
        #region Fields
        private List<MacroCode> macrolist;
        private bool iscoderunning; 
        #endregion

        #region Events
        /// <summary>
        /// Occurs when one of the macro codes methods returns an error.
        /// </summary>
        public event MacroErrorEventHandler ErrorOccured;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MacroCodeManager"/> class.
        /// </summary>
        internal MacroCodeManager()
        {
            macrolist = new List<MacroCode>();
            iscoderunning = false;
        } 
        #endregion

        #region Destructors
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="MacroCodeManager"/> is reclaimed by garbage collection.
        /// </summary>
        ~MacroCodeManager()
        {
            StripEventHandlers();
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Adds the macro.
        /// </summary>
        /// <param name="macro">The macro.</param>
        internal void AddMacro(MacroCode macro)
        {
            macro.ErrorOccured += new MacroErrorEventHandler(OnErrorOccured);            
            macrolist.Add(macro);
        }

        private void StripEventHandlers()
        {
            foreach (MacroCode macro in macrolist)
            {
                macro.ErrorOccured -= new MacroErrorEventHandler(OnErrorOccured);
            }
        }

        /// <summary>
        /// Clears the macros.
        /// </summary>
        internal void ClearMacros()
        {
            StripEventHandlers();
            macrolist.Clear();
        }

        void OnErrorOccured(Exception ex)
        {
            ErrorOccured.Invoke(ex);
        }

        /// <summary>
        /// Starts the code.
        /// </summary>
        public void StartCode()
        {
            if (MacroCount > 0)
            {
                foreach (MacroCode macro in macrolist)
                {
                    macro.IsSuspended = false;
                }
                iscoderunning = true;
            }
        }

        /// <summary>
        /// Stops the code.
        /// </summary>
        public void StopCode()
        {
            if (MacroCount > 0)
            {
                foreach (MacroCode macro in macrolist)
                {
                    macro.IsSuspended = true;
                }
                iscoderunning = false;
            }
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Gets a value indicating whether the macros are running.
        /// </summary>
        /// <value><c>true</c> if the macros are running; otherwise, <c>false</c>.</value>
        public bool MacrosAreRunning
        {
            get
            {
                return iscoderunning;
            }
        }

        /// <summary>
        /// Gets the macro count.
        /// </summary>
        /// <value>The macro count.</value>
        public int MacroCount
        {
            get
            {
                return macrolist.Count;
            }
        }
        #endregion
    }
}
