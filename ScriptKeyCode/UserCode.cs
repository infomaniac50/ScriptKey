using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Utility;
using System.Windows.Forms;
using System.Diagnostics;
namespace ScriptKeyCode
{


    /// <summary>
    /// Provides access to the user code.
    /// </summary>
    public static class UserCode
    {
        /// <summary>
        /// Saves the code.
        /// </summary>
        /// <param name="FilePath">The file path.</param>
        /// <param name="Code">The code.</param>
        public static void Save(string FilePath, string Code)
        {
            File.WriteAllText(FilePath, Code);
        }

        /// <summary>
        /// Loads the code.
        /// </summary>
        /// <param name="FilePath">The file path.</param>
        /// <returns>A string containing the code.</returns>
        public static string Load(string FilePath)
        {
            return File.ReadAllText(FilePath);
        }
    }
}
