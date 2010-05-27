namespace ScriptKeyApp
{
    /// <summary>
    /// Options form.
    /// </summary>
    partial class ReferenceAssembliesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveAssembly = new System.Windows.Forms.Button();
            this.btnAddAssembly = new System.Windows.Forms.Button();
            this.AssembliesListBox = new System.Windows.Forms.ListBox();
            this.AssemblyFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(452, 236);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnRemoveAssembly);
            this.groupBox1.Controls.Add(this.btnAddAssembly);
            this.groupBox1.Controls.Add(this.AssembliesListBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(515, 218);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "ReferenceAssemblies";
            // 
            // btnRemoveAssembly
            // 
            this.btnRemoveAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveAssembly.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnRemoveAssembly.Location = new System.Drawing.Point(434, 48);
            this.btnRemoveAssembly.Name = "btnRemoveAssembly";
            this.btnRemoveAssembly.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveAssembly.TabIndex = 4;
            this.btnRemoveAssembly.Text = "Remove";
            this.btnRemoveAssembly.UseVisualStyleBackColor = true;
            this.btnRemoveAssembly.Click += new System.EventHandler(this.btnRemoveAssembly_Click);
            // 
            // btnAddAssembly
            // 
            this.btnAddAssembly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddAssembly.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAddAssembly.Location = new System.Drawing.Point(434, 19);
            this.btnAddAssembly.Name = "btnAddAssembly";
            this.btnAddAssembly.Size = new System.Drawing.Size(75, 23);
            this.btnAddAssembly.TabIndex = 3;
            this.btnAddAssembly.Text = "Add";
            this.btnAddAssembly.UseVisualStyleBackColor = true;
            this.btnAddAssembly.Click += new System.EventHandler(this.btnAddAssembly_Click);
            // 
            // AssembliesListBox
            // 
            this.AssembliesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.AssembliesListBox.FormattingEnabled = true;
            this.AssembliesListBox.IntegralHeight = false;
            this.AssembliesListBox.Location = new System.Drawing.Point(6, 19);
            this.AssembliesListBox.Name = "AssembliesListBox";
            this.AssembliesListBox.Size = new System.Drawing.Size(422, 193);
            this.AssembliesListBox.TabIndex = 0;
            // 
            // AssemblyFileDialog
            // 
            this.AssemblyFileDialog.Filter = "DLL Files|*.dll";
            this.AssemblyFileDialog.InitialDirectory = "C:\\Windows\\Microsoft.NET\\Framework\\v2.0.50727";
            this.AssemblyFileDialog.Title = "Select an Assembly";
            // 
            // ReferenceAssembliesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 271);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ReferenceAssembliesForm";
            this.ShowInTaskbar = false;
            this.Text = "References";
            this.Load += new System.EventHandler(this.Options_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox AssembliesListBox;
        private System.Windows.Forms.Button btnRemoveAssembly;
        private System.Windows.Forms.Button btnAddAssembly;
        private System.Windows.Forms.OpenFileDialog AssemblyFileDialog;
    }
}