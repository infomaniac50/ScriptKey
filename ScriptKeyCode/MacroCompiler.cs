using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.IO;
using System.Windows.Forms;
namespace ScriptKeyCode
{
    /// <summary>
    /// Compiles user created code.
    /// </summary>
    public static class MacroCompiler
    {
        #region Fields
        private static CSharpCodeProvider cp = new CSharpCodeProvider();
        private static CompilerParameters param = new CompilerParameters();
        #endregion

        static MacroCompiler()
        {
            Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {
            DeleteOldDll();
        }

        #region Properties
        /// <summary>
        /// Gets the compiler errors.
        /// </summary>
        /// <value>The errors.</value>
        public static string[] Errors
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the compiler status.
        /// </summary>
        /// <value>The compiler status.</value>
        public static CompilerStatus Status
        {
            get;
            private set;
        }
        #endregion

        #region Methods
        private static void DeleteOldDll()
        {
            if (File.Exists(CodeHost.AssemblyPath))
                File.Delete(CodeHost.AssemblyPath);
        }

        //gets the strings from each of the errors in the compiler error collection
        private static string[] GetErrorStrings(CompilerErrorCollection errors)
        {
            //a list to hold the error strings
            List<string> errorstrings = new List<string>();

            //for each of the errors the compiler returned
            foreach (CompilerError error in errors)
            {
                //add it to the list as a string
                errorstrings.Add(error.ToString());
            }

            //return the errors
            return errorstrings.ToArray();
        }

        /// <summary>
        /// Compiles the code with the specified reference assemblies into a dll file.
        /// </summary>
        /// <param name="ReferenceAssemblies">The reference assemblies.</param>
        /// <param name="Code">The code.</param>
        public static void Compile(string[] ReferenceAssemblies, string Code)
        {
            DeleteOldDll();            
            CodeHost.Stop();
#if !DEBUG
            param.CompilerOptions = @"/optimize";
#endif
            //add user references
            param.ReferencedAssemblies.AddRange(ReferenceAssemblies);

            //add our references
            //for output support
            param.ReferencedAssemblies.Add("API.dll");
            //for input support
            param.ReferencedAssemblies.Add("InputLib.dll");
            //for joystick support
            param.ReferencedAssemblies.Add("Soopah.XNA.Input.dll");


            //set the default status
            Status = CompilerStatus.Success;

            try
            {
                //compile the source code
                CompilerResults cr = cp.CompileAssemblyFromSource(param, Code);

                //check if the code has warnings
                //if so then elevate status to a warning
                if (cr.Errors.HasWarnings)
                    Status = CompilerStatus.Warning;

                //check if the code has errors
                //if so then elevate status to a error
                if (cr.Errors.HasErrors)
                    Status = CompilerStatus.Error;

                //if the code has any warnings or errors, format them as strings
                if (cr.Errors.Count > 0)
                    Errors = GetErrorStrings(cr.Errors);
                else
                    Errors = null; //else set errors to null

                //make sure the code does not have errors before trying to load it.
                if (!cr.Errors.HasErrors)
                    CodeHost.AssemblyPath = cr.PathToAssembly; //if not then set the user code assembly path.
            }
            catch (Exception ex)
            {
                //catch any unresolvable errors and show them to the user.
                Status = CompilerStatus.AppError;
                Errors = new string[] { ex.ToString() };
            }
        }
        #endregion
    }
}
