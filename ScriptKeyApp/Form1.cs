using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ScriptKeyCode;
using System.IO;

using DerekChafin.Logging;
namespace ScriptKeyApp
{
    /// <summary>
    /// Main form.
    /// </summary>
    public partial class frmEditor : Form
    {
        #region Fields
        bool isusercode;
        Dictionary<string, string> examplefiles = new Dictionary<string, string>();
        string[] args = Environment.GetCommandLineArgs();
        ReferenceAssembliesForm frmeditreferences = new ReferenceAssembliesForm();
        CompilerErrorForm frmerror = new CompilerErrorForm();
        OptionsForm frmoptions = new OptionsForm();
        AboutBox frmabout = new AboutBox();
        ExamplePickerDialog diaexamplepicker;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="frmEditor"/> class.
        /// </summary>
        public frmEditor()
        {            
            InitializeComponent();
        }
        #endregion

        #region Methods
        private void SetStatusError(string Text)
        {
            SetStatus(Text, Color.Red);
        }

        private void SetStatusOk(string Text)
        {
            SetStatus(Text, Color.Black);
        }

        private void SetStatus(string Text, Color StatusColor)
        {
            lblStatus.Text = Text;
            lblStatus.ForeColor = StatusColor;
        }

        private void RunCode()
        {
            btnNewCode.Enabled = false;
            btnSaveCode.Enabled = false;
            btnLoadCode.Enabled = false;
            btnEditReferences.Enabled = false;
            btnCompileCode.Enabled = false;
            btnRunCode.Enabled = false;
            btnStopCode.Enabled = true;
            CodeBox.Enabled = false;
            mnuRunCode.Enabled = false;
            mnuStopCode.Enabled = true;
            CodeHost.Start();
        }

        private void StopCode()
        {
            CodeHost.Stop();
            CodeBox.Enabled = true;
            btnCompileCode.Enabled = true;
            btnRunCode.Enabled = true;
            btnStopCode.Enabled = false;
            mnuRunCode.Enabled = true;
            mnuStopCode.Enabled = false;
            btnNewCode.Enabled = true;
            btnSaveCode.Enabled = true;
            btnLoadCode.Enabled = true;
            btnEditReferences.Enabled = true;
        }

        private void NewCode()
        {
            LoadCode(GetExample("Untitled"));
            isusercode = false;
            SetStatusOk("Ready");
        }

        private void SaveCode(string FileName)
        {
            try
            {
                UserCode.Save(FileName, CodeBox.Text);
                this.Text = System.IO.Path.GetFileName(FileName);
                SetStatusOk("File Saved");
                btnSaveCode.Enabled = false;
                isusercode = true;
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#else
                    SetStatusError(ex.Message);
#endif
            }
        }

        private void SaveCodeAs()
        {
            if (CodeSaveDialog.ShowDialog() == DialogResult.OK)
            {
                SaveCode(CodeSaveDialog.FileName);
            }
        }

        private void LoadExamples()
        {
            string[] files = Directory.GetFiles(Path.Combine(Application.StartupPath, "Examples\\"), "*.skc", SearchOption.AllDirectories);

            foreach (string file in files)
            {
                examplefiles.Add(Path.GetFileNameWithoutExtension(file), file);
            }
        }

        private string GetExample(string Example)
        {
            if (examplefiles.ContainsKey(Example))
                return examplefiles[Example];
            else
                return "";
        }

        private void LoadCode(string FilePath)
        {
            isusercode = true;
            try
            {
                CodeBox.Text = UserCode.Load(FilePath);
                this.Text = System.IO.Path.GetFileNameWithoutExtension(FilePath);
                SetStatusOk("File Opened");
            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#else
                SetStatusError(ex.Message);
#endif
            }

        }
        #endregion

        #region Form Event Methods
        private void frmEditor_SizeChanged(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MinimizeToTray)
            {
                switch (this.WindowState)
                {
                    case FormWindowState.Maximized:
                        break;
                    case FormWindowState.Minimized:
                        this.ShowInTaskbar = false;
                        break;
                    case FormWindowState.Normal:
                        this.ShowInTaskbar = true;
                        break;
                    default:
                        break;
                }

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LogWriter.FileName = "Debug.log";
            if (!Properties.Settings.Default.ShowErrors)
                LogWriter.ClearLog();
            else
                btnViewErrorLog.Enabled = true;

            Properties.Settings.Default.ShowErrors = false;

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            LoadExamples();
            List<string> keys = new List<string>();

            foreach (var key in examplefiles.Keys)
            {
                keys.Add((string)key);
            }

            diaexamplepicker = new ExamplePickerDialog(keys);

            if (args.Length > 1 && System.IO.File.Exists(args[1]))
                LoadCode(args[1]);
            else
                NewCode();

            CodeHost.ErrorOccured += new MacroErrorEventHandler(OnErrorOccured);
        }

        void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogWriter.WriteEntry(((Exception)e.ExceptionObject).ToString(), true, TraceEventType.Critical);
            btnViewErrorLog.Enabled = true;
            Properties.Settings.Default.ShowErrors = true;
        }

        void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LogWriter.WriteEntry(e.Exception.ToString(), true, TraceEventType.Critical);
            btnViewErrorLog.Enabled = true;
            Properties.Settings.Default.ShowErrors = true;
        }

        private void OnErrorOccured(Exception ex)
        {
            if (InvokeRequired)
            {
                this.Invoke(new MacroErrorEventHandler(OnErrorOccured), (object)ex);
            }
            else
            {
                StopCode();
                frmerror.SetErrors(ex.ToString());
                frmerror.Show();
            }
        }

        private void StatusIcon_DoubleClick(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
        }
        #endregion

        #region Button Event Methods
        #region Execution
        private void btnRunCode_Click(object sender, EventArgs e)
        {
            RunCode();
        }

        private void btnStopCode_Click(object sender, EventArgs e)
        {
            StopCode();
        }

        private void btnCompileCode_Click(object sender, EventArgs e)
        {
            btnRunCode.Enabled = false;
            mnuRunCode.Enabled = false;
            SetStatusOk("Building Source");
            lblCompileStatus.Image = Properties.Resources.compile_unknown;
            MacroCompiler.Compile(Properties.Settings.Default.ReferenceAssemblies.Split(','), CodeBox.Text);
            switch (MacroCompiler.Status)
            {
                case CompilerStatus.AppError:
                    SetStatusError("Application Error");
                    lblCompileStatus.Image = Properties.Resources.compile_unknown;
                    LogWriter.WriteEntry(MacroCompiler.Errors[0], true, TraceEventType.Error);
                    btnViewErrorLog.Enabled = true; 
                    break;
                case CompilerStatus.Error:
                    SetStatusError("Compiler Error");
                    lblCompileStatus.Image = Properties.Resources.compile_error;
                    break;
                case CompilerStatus.Warning:
                    SetStatusError("Compiler Warning");
                    lblCompileStatus.Image = Properties.Resources.compile_warning;
                    break;
                case CompilerStatus.Success:
                    btnRunCode.Enabled = true;
                    mnuRunCode.Enabled = true;
                    SetStatusOk("Compiler Success");
                    lblCompileStatus.Image = Properties.Resources.compile_success;
                    break;
                default:
                    break;
            }

            if (MacroCompiler.Errors != null && MacroCompiler.Errors.Length > 0)
            {
                frmerror.SetErrors(MacroCompiler.Errors);
                frmerror.Show();
            }

        }
        #endregion

        #region Options
        private void btnShowOptions_Click(object sender, EventArgs e)
        {
            frmoptions.ShowDialog();
        }

        private void btnEditReferences_Click(object sender, EventArgs e)
        {
            frmeditreferences.Show();
        }
        #endregion

        #region IO


        private void btnViewErrorLog_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(LogWriter.FilePath);
        }

        private void btnPrintCode_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadCode_Click(object sender, EventArgs e)
        {

        }

        private void btnLoadExample_Click(object sender, EventArgs e)
        {
            if (diaexamplepicker.ShowDialog() == DialogResult.OK)
            {
                LoadCode(examplefiles[diaexamplepicker.SelectedExample]);
            }
        }

        private void btnSaveAs_Click(object sender, EventArgs e)
        {
            SaveCodeAs();
        }

        private void btnSaveCode_Click(object sender, EventArgs e)
        {
            if (isusercode)
            {
                SaveCode(CodeSaveDialog.FileName);
            }
            else
            {
                SaveCodeAs();
            }
        }

        private void btnNewCode_Click(object sender, EventArgs e)
        {
            NewCode();
        }
        #endregion

        #region Edit
        private void btnCutCode_Click(object sender, EventArgs e)
        {
            CodeBox.Cut();
        }

        private void btnCopyCode_Click(object sender, EventArgs e)
        {
            CodeBox.Copy();
        }

        private void btnPasteCode_Click(object sender, EventArgs e)
        {
            CodeBox.Paste();
        }
        #endregion

        #region Help
        private void btnShowAbout_Click(object sender, EventArgs e)
        {
            frmabout.ShowDialog();
        }

        private void btnOpenHelp_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(Path.Combine(Application.StartupPath , "Help\\ScriptKey Help.chm"));
        }
        #endregion
        #endregion

        #region Context Menu Event Methods
        private void mnuExitCode_Click(object sender, EventArgs e)
        {
            StopCode();
            Close();
        }

        private void mnuRunCode_Click(object sender, EventArgs e)
        {
            RunCode();
        }

        private void mnuStopCode_Click(object sender, EventArgs e)
        {
            StopCode();
        }
        #endregion

        #region TextBox Event Methods
        private void CodeBox_TextChanged(object sender, EventArgs e)
        {
            btnRunCode.Enabled = false;
            btnStopCode.Enabled = false;
            btnSaveCode.Enabled = true;
            SetStatusOk("Ready");
        }

       #endregion


    }
}
