using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScriptKeyApp
{
    public partial class CompilerErrorForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CompilerErrorForm"/> class.
        /// </summary>
        public CompilerErrorForm()
        {
            InitializeComponent();            
        }

        /// <summary>
        /// Sets the errors.
        /// </summary>
        /// <param name="Errors">The errors.</param>
        public void SetErrors(string[] Errors)
        {
            //format the errors for output
            FormatErrors(Errors);
        }

        /// <summary>
        /// Sets the errors.
        /// </summary>
        /// <param name="Error">The error.</param>
        public void SetErrors(string Error)
        {
            SetErrors(new string[] { Error });
        }

        /// <summary>
        /// Sets the error.
        /// </summary>
        /// <param name="ex">The exception.</param>
        public void SetErrors(Exception ex)
        {
            SetErrors(ex.ToString());            
        }

        //separates the error strings with new lines
        private void FormatErrors(string[] Errors)
        {
            //set the default string so we can append to it.
            txtError.Text = "";
            //for each error
            foreach (string error in Errors)
            {
                //append it and separate it from the next error string.
                txtError.Text += error + "\r\n\r\n";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
