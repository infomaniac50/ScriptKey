using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace API.Output
{
    /// <summary>
    /// Allows user code to output information to the screen.
    /// </summary>
    public partial class OutputForm : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="OutputForm"/> class.
        /// </summary>
        public OutputForm()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
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
            OutputText += Value;
        }

        /// <summary>
        /// Clears the output.
        /// </summary>
        public void Clear()
        {
            OutputText = "";
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the output text.
        /// </summary>
        /// <value>The output text.</value>        
        public string OutputText
        {
            get
            {
                return txtOutput.Text;
            }
            set
            {
                txtOutput.Text = value;
            }
        }



        #endregion
    }
}

