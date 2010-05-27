using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
namespace ScriptKeyCode
{
    /// <summary>
    /// A server that recieves messages from a remote client.
    /// </summary>
    public class RemoteServer
    {
        #region Fields
        private IpcChannel serverchannel;
        private ObjRef ref1;
        private RemoteObject RemoteObj; 
        #endregion

        #region Events
        /// <summary>
        /// Occurs when an error is sent from a client.
        /// </summary>
        public event MacroErrorEventHandler ErrorSent;
        /// <summary>
        /// Occurs when a message is sent from a client.
        /// </summary>
        public event MessageSentEventHander MessageSent; 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteServer"/> class.
        /// </summary>
        public RemoteServer()
        {
            RemoteObj = new RemoteObject();
            serverchannel = new IpcChannel("localhost:15000");
            ChannelServices.RegisterChannel(serverchannel, false);
            ref1 = RemotingServices.Marshal(RemoteObj, "RemoteObject.rem");
            Console.WriteLine("ObjRef1 URI: " + ref1.URI);
            RemoteObj.ObjectSent += new ObjectSentEventHandler(OnObjectSent);
        }
        #endregion

        #region Destructors
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="RemoteServer"/> is reclaimed by garbage collection.
        /// </summary>
        ~RemoteServer()
        {
            RemoteObj.ObjectSent -= new ObjectSentEventHandler(OnObjectSent);
            RemotingServices.Disconnect(RemoteObj);
        } 
        #endregion

        #region Methods
        void OnObjectSent(object Obj)
        {
            ObjectMessage container = (ObjectMessage)Obj;

            switch (container.MessageType)
            {
                case "message":
                    OnMessageSent((string)container.Message);
                    break;
                case "error":
                    OnErrorSent((Exception)container.Message);
                    break;
                default:
                    break;
            }
        }

        void OnMessageSent(string message)
        {
            if (MessageSent != null)
                MessageSent.Invoke(message);
        }

        void OnErrorSent(Exception ex)
        {
            if (ErrorSent != null)
                ErrorSent.Invoke(ex);
        } 
        #endregion
    }
}
