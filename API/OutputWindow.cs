using System;
using System.Collections.Generic;

using System.Text;

namespace API
{
    /// <summary>
    /// Shows output to the user.
    /// </summary>
    public class OutputWindow
    {
        #region Fields
        OutputForm outputform; 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputWindow"/> class.
        /// </summary>
        public OutputWindow()
        {
            outputform = new OutputForm();
            Clear();
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Shows the output window.
        /// </summary>
        public void Show()
        {
            outputform.Show();
        }

        /// <summary>
        /// Hides the output window.
        /// </summary>
        public void Hide()
        {
            outputform.Hide();
        }

        /// <summary>
        /// Writes the specified value followed by a newline character to the output.
        /// </summary>
        /// <param name="Value">The value to write.</param>
        public void WriteLine(string Value)
        {
            Write(Value + "\r\n");
        }

        /// <summary>
        /// Writes a newline character to the output.
        /// </summary>
        public void WriteLine()
        {
            WriteLine("");
        }
        /// <summary>
        /// Writes the specified value to the output.
        /// </summary>
        /// <param name="Value">The value to write.</param>
        public void Write(string Value)
        {
            outputform.OutputText += Value;
        }

        /// <summary>
        /// Clears the output.
        /// </summary>
        public void Clear()
        {
            outputform.OutputText = "";
        }
        #endregion
    }
}
