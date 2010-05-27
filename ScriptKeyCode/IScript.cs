using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Lifetime;
namespace ScriptKeyCode
{
    /// <summary>
    /// Provides communication between the main application and the user code
    /// </summary>
    public interface IScript
    {
        /// <summary>
        /// Loads the specified assembly.
        /// </summary>
        /// <param name="AssemblyPath">The assembly path.</param>
        void Load(string AssemblyPath);
        /// <summary>
        /// Starts the user code.
        /// </summary>
        void Start();
        /// <summary>
        /// Stops the user code.
        /// </summary>
        void Stop();
    }
}
