using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptKeyCode
{
    /// <summary>
    /// Defines an interface to send objects remotely
    /// </summary>
    public interface IRemoteObject
    {

        /// <summary>
        /// Sends an object.
        /// </summary>
        /// <param name="Obj">The object to send.</param>
        void SendObject(Object Obj);
    }
}
