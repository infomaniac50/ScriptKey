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
    internal partial class OutputForm : Form
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

