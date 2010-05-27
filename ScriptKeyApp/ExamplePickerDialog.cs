using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScriptKeyApp
{
    /// <summary>
    /// A dialog to select code samples.
    /// </summary>
    public partial class ExamplePickerDialog : Form
    {
        IEnumerable<string> examplefiles;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExamplePickerDialog"/> class.
        /// </summary>
        /// <param name="Examples">The examples.</param>
        public ExamplePickerDialog(IEnumerable<string> Examples)
        {
            examplefiles = Examples;
            InitializeComponent();
        }

        private void frmExamplePicker_Load(object sender, EventArgs e)
        {cmbExample.Items.Clear();
            foreach (string file in examplefiles)
            {
                if (file != "Untitled")
                    cmbExample.Items.Add(file);
            }
        }

        /// <summary>
        /// Gets the selected example.
        /// </summary>
        /// <value>The selected example.</value>
        public string SelectedExample
        {
            get;
            private set;
        }

        private void cmbExample_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedExample = (string)cmbExample.SelectedItem;
        }
    }
}
