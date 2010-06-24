using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ScriptKeyApp.Properties;
using System.IO;
using ScriptKeyCode;

namespace ScriptKeyApp
{
    public partial class ReferenceAssembliesForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReferenceAssembliesForm"/> class.
        /// </summary>
        public ReferenceAssembliesForm()
        {
            InitializeComponent();
        }

        private void btnAddAssembly_Click(object sender, EventArgs e)
        {
            if (AssemblyFileDialog.ShowDialog() == DialogResult.OK)
            {
                if (Util.IsDotNetAssembly(AssemblyFileDialog.FileName))
                    AssembliesListBox.Items.Add(Path.GetFileName(AssemblyFileDialog.FileName));
                else
                    MessageBox.Show("The file is not a .NET assembly.");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            string output = "";
            foreach (object obj in AssembliesListBox.Items)
            {
                output += (string)obj + ",";
            }
            output = output.Remove(output.Length - 1);
            Settings.Default.ReferenceAssemblies = output;
            Settings.Default.Save();
            this.Hide();
        }

        private void Options_Load(object sender, EventArgs e)
        {
            AssembliesListBox.Items.Clear();
            string[] assemblies = Settings.Default.ReferenceAssemblies.Split(',');
            AssembliesListBox.Items.AddRange(assemblies);
        }

        private void btnRemoveAssembly_Click(object sender, EventArgs e)
        {
            AssembliesListBox.Items.RemoveAt(AssembliesListBox.SelectedIndex);
        }




    }
}
