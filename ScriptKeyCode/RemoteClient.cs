using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Ipc;
using System.Threading;
namespace ScriptKeyCode
{
    /// <summary>
    /// A client that sends messages to a remote server.
    /// </summary>
    public class RemoteClient
    {
        #region Fields
        private IpcChannel clientchannel;
        RemoteObject RemoteObj;
        private Thread mythread;
        private ILease lease;
        private RemoteClientSponser sponser; 
        #endregion
        
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteClient"/> class.
        /// </summary>
        public RemoteClient()
        {
            clientchannel = new IpcChannel();
            ChannelServices.RegisterChannel(clientchannel, false);
            RemotingConfiguration.RegisterWellKnownClientType(typeof(RemoteObject), "ipc://localhost:15000/RemoteObject.rem");
            RemoteObj = new RemoteObject();
            sponser = new RemoteClientSponser("RemoteClient");
            lease = (ILease)RemoteObj.GetLifetimeService();
            lease.Register(sponser);
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Sends a message to the server.
        /// </summary>
        /// <param name="message">The message.</param>
        public void SendMessage(string message)
        {
            SendObject(new ObjectMessage() { Message = message, MessageType = "message" });
        }

        /// <summary>
        /// Sends an exception to the server.
        /// </summary>
        /// <param name="Error">The error.</param>
        public void SendException(Exception Error)
        {
            SendObject(new ObjectMessage() { Message = Error, MessageType = "error" });
        }

        private void SendObject(ObjectMessage Obj)
        {
            try
            {
                mythread = new Thread(new ParameterizedThreadStart(RemoteObj.SendObject));
                mythread.Start(Obj);
            }
            catch (Exception)
            {
                Console.WriteLine("Cannot access the remote object");
            }

        } 
        #endregion
    }
}
