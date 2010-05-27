using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ScriptKeyApp
{
    /// <summary>
    /// Shows the user options.
    /// </summary>
    public partial class OptionsForm : Form
    {


        /// <summary>
        /// Initializes a new instance of the <see cref="OptionsForm"/> class.
        /// </summary>
        public OptionsForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {            
            Properties.Settings.Default.MinimizeToTray = chkMinimizeToTray.Checked;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
            chkMinimizeToTray.Checked = Properties.Settings.Default.MinimizeToTray;
        }

    }
}
