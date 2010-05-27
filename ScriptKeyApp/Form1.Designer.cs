namespace ScriptKeyApp
{
    partial class frmEditor
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
            this.components = new System.ComponentModel.Container();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblCompileStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.CodeBox = new System.Windows.Forms.RichTextBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewCode = new System.Windows.Forms.ToolStripButton();
            this.btnLoadCode = new System.Windows.Forms.ToolStripSplitButton();
            this.btnLoadExample = new System.Windows.Forms.ToolStripMenuItem();
            this.btnSaveCode = new System.Windows.Forms.ToolStripButton();
            this.btnSaveAs = new System.Windows.Forms.ToolStripButton();
            this.btnPrintCode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCutCode = new System.Windows.Forms.ToolStripButton();
            this.btnCopyCode = new System.Windows.Forms.ToolStripButton();
            this.btnPasteCode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.btnCompileCode = new System.Windows.Forms.ToolStripButton();
            this.btnRunCode = new System.Windows.Forms.ToolStripButton();
            this.btnStopCode = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnShowOptions = new System.Windows.Forms.ToolStripButton();
            this.btnEditReferences = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.btnViewErrorLog = new System.Windows.Forms.ToolStripButton();
            this.StatusIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.NotifyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuRunCode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuStopCode = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuExitCode = new System.Windows.Forms.ToolStripMenuItem();
            this.CodeOpenDialog = new System.Windows.Forms.OpenFileDialog();
            this.CodeSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnShowAbout = new System.Windows.Forms.ToolStripSplitButton();
            this.btnOpenHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.NotifyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.CodeBox);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(430, 268);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(430, 315);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblCompileStatus,
            this.toolStripStatusLabel1,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(430, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // lblCompileStatus
            // 
            this.lblCompileStatus.Image = global::ScriptKeyApp.Properties.Resources.compile_unknown;
            this.lblCompileStatus.Name = "lblCompileStatus";
            this.lblCompileStatus.Size = new System.Drawing.Size(16, 17);
            this.lblCompileStatus.ToolTipText = "ss";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(42, 17);
            this.toolStripStatusLabel1.Text = "Status:";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(38, 17);
            this.lblStatus.Text = "Ready";
            // 
            // CodeBox
            // 
            this.CodeBox.AcceptsTab = true;
            this.CodeBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeBox.Location = new System.Drawing.Point(0, 0);
            this.CodeBox.Name = "CodeBox";
            this.CodeBox.Size = new System.Drawing.Size(430, 268);
            this.CodeBox.TabIndex = 0;
            this.CodeBox.Text = "";
            this.CodeBox.WordWrap = false;
            this.CodeBox.TextChanged += new System.EventHandler(this.CodeBox_TextChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewCode,
            this.btnLoadCode,
            this.btnSaveCode,
            this.btnSaveAs,
            this.btnPrintCode,
            this.toolStripSeparator6,
            this.btnCutCode,
            this.btnCopyCode,
            this.btnPasteCode,
            this.toolStripSeparator7,
            this.btnCompileCode,
            this.btnRunCode,
            this.btnStopCode,
            this.toolStripSeparator1,
            this.btnShowOptions,
            this.btnEditReferences,
            this.toolStripSeparator8,
            this.btnViewErrorLog,
            this.btnShowAbout});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(427, 25);
            this.toolStrip1.TabIndex = 1;
            // 
            // btnNewCode
            // 
            this.btnNewCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewCode.Image = global::ScriptKeyApp.Properties.Resources.document;
            this.btnNewCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewCode.Name = "btnNewCode";
            this.btnNewCode.Size = new System.Drawing.Size(23, 22);
            this.btnNewCode.Text = "&New";
            this.btnNewCode.Click += new System.EventHandler(this.btnNewCode_Click);
            // 
            // btnLoadCode
            // 
            this.btnLoadCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLoadCode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadExample});
            this.btnLoadCode.Image = global::ScriptKeyApp.Properties.Resources.folder_horizontal_open;
            this.btnLoadCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadCode.Name = "btnLoadCode";
            this.btnLoadCode.Size = new System.Drawing.Size(32, 22);
            this.btnLoadCode.Text = "&Open";
            this.btnLoadCode.ButtonClick += new System.EventHandler(this.btnLoadCode_Click);
            // 
            // btnLoadExample
            // 
            this.btnLoadExample.Name = "btnLoadExample";
            this.btnLoadExample.Size = new System.Drawing.Size(140, 22);
            this.btnLoadExample.Text = "Load Example";
            this.btnLoadExample.Click += new System.EventHandler(this.btnLoadExample_Click);
            // 
            // btnSaveCode
            // 
            this.btnSaveCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveCode.Image = global::ScriptKeyApp.Properties.Resources.disk;
            this.btnSaveCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveCode.Name = "btnSaveCode";
            this.btnSaveCode.Size = new System.Drawing.Size(23, 22);
            this.btnSaveCode.Text = "&Save";
            this.btnSaveCode.Click += new System.EventHandler(this.btnSaveCode_Click);
            // 
            // btnSaveAs
            // 
            this.btnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnSaveAs.Image = global::ScriptKeyApp.Properties.Resources.disks;
            this.btnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSaveAs.Name = "btnSaveAs";
            this.btnSaveAs.Size = new System.Drawing.Size(23, 22);
            this.btnSaveAs.Text = "Save As";
            this.btnSaveAs.Click += new System.EventHandler(this.btnSaveAs_Click);
            // 
            // btnPrintCode
            // 
            this.btnPrintCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintCode.Enabled = false;
            this.btnPrintCode.Image = global::ScriptKeyApp.Properties.Resources.printer;
            this.btnPrintCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintCode.Name = "btnPrintCode";
            this.btnPrintCode.Size = new System.Drawing.Size(23, 22);
            this.btnPrintCode.Text = "&Print";
            this.btnPrintCode.Visible = false;
            this.btnPrintCode.Click += new System.EventHandler(this.btnPrintCode_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCutCode
            // 
            this.btnCutCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCutCode.Image = global::ScriptKeyApp.Properties.Resources.scissors_blue;
            this.btnCutCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCutCode.Name = "btnCutCode";
            this.btnCutCode.Size = new System.Drawing.Size(23, 22);
            this.btnCutCode.Text = "C&ut";
            this.btnCutCode.Click += new System.EventHandler(this.btnCutCode_Click);
            // 
            // btnCopyCode
            // 
            this.btnCopyCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopyCode.Image = global::ScriptKeyApp.Properties.Resources.notebooks;
            this.btnCopyCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopyCode.Name = "btnCopyCode";
            this.btnCopyCode.Size = new System.Drawing.Size(23, 22);
            this.btnCopyCode.Text = "&Copy";
            this.btnCopyCode.Click += new System.EventHandler(this.btnCopyCode_Click);
            // 
            // btnPasteCode
            // 
            this.btnPasteCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPasteCode.Image = global::ScriptKeyApp.Properties.Resources.clipboard_paste_document_text;
            this.btnPasteCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPasteCode.Name = "btnPasteCode";
            this.btnPasteCode.Size = new System.Drawing.Size(23, 22);
            this.btnPasteCode.Text = "&Paste";
            this.btnPasteCode.Click += new System.EventHandler(this.btnPasteCode_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCompileCode
            // 
            this.btnCompileCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCompileCode.Image = global::ScriptKeyApp.Properties.Resources.compile_success;
            this.btnCompileCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCompileCode.Name = "btnCompileCode";
            this.btnCompileCode.Size = new System.Drawing.Size(23, 22);
            this.btnCompileCode.Text = "Compile";
            this.btnCompileCode.Click += new System.EventHandler(this.btnCompileCode_Click);
            // 
            // btnRunCode
            // 
            this.btnRunCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnRunCode.Enabled = false;
            this.btnRunCode.Image = global::ScriptKeyApp.Properties.Resources.run;
            this.btnRunCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRunCode.Name = "btnRunCode";
            this.btnRunCode.Size = new System.Drawing.Size(23, 22);
            this.btnRunCode.Text = "Run";
            this.btnRunCode.Click += new System.EventHandler(this.btnRunCode_Click);
            // 
            // btnStopCode
            // 
            this.btnStopCode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnStopCode.Enabled = false;
            this.btnStopCode.Image = global::ScriptKeyApp.Properties.Resources.stop;
            this.btnStopCode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStopCode.Name = "btnStopCode";
            this.btnStopCode.Size = new System.Drawing.Size(23, 22);
            this.btnStopCode.Text = "Pause";
            this.btnStopCode.Click += new System.EventHandler(this.btnStopCode_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnShowOptions
            // 
            this.btnShowOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowOptions.Image = global::ScriptKeyApp.Properties.Resources.gear;
            this.btnShowOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowOptions.Name = "btnShowOptions";
            this.btnShowOptions.Size = new System.Drawing.Size(23, 22);
            this.btnShowOptions.Text = "Show Options";
            this.btnShowOptions.Click += new System.EventHandler(this.btnShowOptions_Click);
            // 
            // btnEditReferences
            // 
            this.btnEditReferences.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditReferences.Image = global::ScriptKeyApp.Properties.Resources.block__pencil;
            this.btnEditReferences.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditReferences.Name = "btnEditReferences";
            this.btnEditReferences.Size = new System.Drawing.Size(23, 22);
            this.btnEditReferences.Text = "Edit Reference Dlls";
            this.btnEditReferences.ToolTipText = "Edit Referenced Dlls";
            this.btnEditReferences.Click += new System.EventHandler(this.btnEditReferences_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(6, 25);
            // 
            // btnViewErrorLog
            // 
            this.btnViewErrorLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnViewErrorLog.Enabled = false;
            this.btnViewErrorLog.Image = global::ScriptKeyApp.Properties.Resources.exclamation;
            this.btnViewErrorLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnViewErrorLog.Name = "btnViewErrorLog";
            this.btnViewErrorLog.Size = new System.Drawing.Size(23, 22);
            this.btnViewErrorLog.Text = "Show Log";
            this.btnViewErrorLog.Click += new System.EventHandler(this.btnViewErrorLog_Click);
            // 
            // StatusIcon
            // 
            this.StatusIcon.ContextMenuStrip = this.NotifyMenu;
            this.StatusIcon.Icon = global::ScriptKeyApp.Properties.Resources.runcode;
            this.StatusIcon.Text = "notifyIcon1";
            this.StatusIcon.Visible = true;
            this.StatusIcon.DoubleClick += new System.EventHandler(this.StatusIcon_DoubleClick);
            // 
            // NotifyMenu
            // 
            this.NotifyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuRunCode,
            this.mnuStopCode,
            this.toolStripSeparator5,
            this.mnuExitCode});
            this.NotifyMenu.Name = "NotifyMenu";
            this.NotifyMenu.Size = new System.Drawing.Size(97, 76);
            // 
            // mnuRunCode
            // 
            this.mnuRunCode.Enabled = false;
            this.mnuRunCode.Name = "mnuRunCode";
            this.mnuRunCode.Size = new System.Drawing.Size(96, 22);
            this.mnuRunCode.Text = "Run";
            this.mnuRunCode.Click += new System.EventHandler(this.mnuRunCode_Click);
            // 
            // mnuStopCode
            // 
            this.mnuStopCode.Enabled = false;
            this.mnuStopCode.Name = "mnuStopCode";
            this.mnuStopCode.Size = new System.Drawing.Size(96, 22);
            this.mnuStopCode.Text = "Stop";
            this.mnuStopCode.Click += new System.EventHandler(this.mnuStopCode_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(93, 6);
            // 
            // mnuExitCode
            // 
            this.mnuExitCode.Name = "mnuExitCode";
            this.mnuExitCode.Size = new System.Drawing.Size(96, 22);
            this.mnuExitCode.Text = "Exit";
            this.mnuExitCode.Click += new System.EventHandler(this.mnuExitCode_Click);
            // 
            // CodeOpenDialog
            // 
            this.CodeOpenDialog.DefaultExt = "*.skc";
            this.CodeOpenDialog.Filter = "ScriptKey Document|*.skc";
            this.CodeOpenDialog.Title = "Select a Script Key document";
            // 
            // CodeSaveDialog
            // 
            this.CodeSaveDialog.DefaultExt = "*.skc";
            this.CodeSaveDialog.Filter = "ScriptKey Document|*.skc";
            this.CodeSaveDialog.Title = "Choose a location for the Script Key document";
            // 
            // btnShowAbout
            // 
            this.btnShowAbout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowAbout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenHelp});
            this.btnShowAbout.Image = global::ScriptKeyApp.Properties.Resources.question_frame;
            this.btnShowAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowAbout.Name = "btnShowAbout";
            this.btnShowAbout.Size = new System.Drawing.Size(32, 22);
            this.btnShowAbout.Text = "He&lp";
            this.btnShowAbout.ButtonClick += new System.EventHandler(this.btnShowAbout_Click);
            // 
            // btnOpenHelp
            // 
            this.btnOpenHelp.Name = "btnOpenHelp";
            this.btnOpenHelp.Size = new System.Drawing.Size(152, 22);
            this.btnOpenHelp.Text = "Open Help";
            this.btnOpenHelp.Click += new System.EventHandler(this.btnOpenHelp_Click);
            // 
            // frmEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 315);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = global::ScriptKeyApp.Properties.Resources.runcode;
            this.Name = "frmEditor";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.SizeChanged += new System.EventHandler(this.frmEditor_SizeChanged);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.NotifyMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.NotifyIcon StatusIcon;
        private System.Windows.Forms.ContextMenuStrip NotifyMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuRunCode;
        private System.Windows.Forms.ToolStripMenuItem mnuStopCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem mnuExitCode;
        private System.Windows.Forms.OpenFileDialog CodeOpenDialog;
        private System.Windows.Forms.SaveFileDialog CodeSaveDialog;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnNewCode;
        private System.Windows.Forms.ToolStripButton btnSaveCode;
        private System.Windows.Forms.ToolStripButton btnPrintCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton btnCutCode;
        private System.Windows.Forms.ToolStripButton btnCopyCode;
        private System.Windows.Forms.ToolStripButton btnPasteCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton btnRunCode;
        private System.Windows.Forms.ToolStripButton btnStopCode;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripButton btnShowOptions;
        private System.Windows.Forms.ToolStripStatusLabel lblCompileStatus;
        private System.Windows.Forms.ToolStripButton btnCompileCode;
        private System.Windows.Forms.RichTextBox CodeBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnEditReferences;
        private System.Windows.Forms.ToolStripSplitButton btnLoadCode;
        private System.Windows.Forms.ToolStripMenuItem btnLoadExample;
        private System.Windows.Forms.ToolStripButton btnSaveAs;
        private System.Windows.Forms.ToolStripButton btnViewErrorLog;
        private System.Windows.Forms.ToolStripSplitButton btnShowAbout;
        private System.Windows.Forms.ToolStripMenuItem btnOpenHelp;
    }
}

