using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting.Lifetime;
namespace ScriptKeyCode
{
    /// <summary>
    /// Sends and reports objects to a remote object.
    /// </summary>
    public class RemoteObject : MarshalByRefObject, IRemoteObject 
    {
        /// <summary>
        /// Obtains a lifetime service object to control the lifetime policy for this instance.
        /// </summary>
        /// <returns>
        /// An object of type <see cref="T:System.Runtime.Remoting.Lifetime.ILease"/> used to control the lifetime policy for this instance. This is the current lifetime service object for this instance if one exists; otherwise, a new lifetime service object initialized to the value of the <see cref="P:System.Runtime.Remoting.Lifetime.LifetimeServices.LeaseManagerPollTime"/> property.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">
        /// The immediate caller does not have infrastructure permission.
        /// </exception>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="RemotingConfiguration, Infrastructure"/>
        /// </PermissionSet>
        public override Object InitializeLifetimeService()
        {
            ILease lease = (ILease)base.InitializeLifetimeService();

            // Normally, the initial lease time would be much longer.
            // It is shortened here for demonstration purposes.
            if (lease.CurrentState == LeaseState.Initial)
            {
                lease.InitialLeaseTime = TimeSpan.FromMinutes(10);
                lease.SponsorshipTimeout = TimeSpan.FromSeconds(120);
                lease.RenewOnCallTime = TimeSpan.FromMinutes(10);
            }
            return lease;
        }


        #region IRemoteObject Members

        /// <summary>
        /// Occurs when an object is sent.
        /// </summary>
        public event ObjectSentEventHandler ObjectSent;

        /// <summary>
        /// Sends an object.
        /// </summary>
        /// <param name="Obj">The object to send.</param>
        public void SendObject(object Obj)
        {
            if (ObjectSent != null)
                ObjectSent.Invoke(Obj);
        }
        #endregion
    }    
}
