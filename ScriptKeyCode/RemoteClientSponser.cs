using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
namespace ScriptKeyCode
{
    /// <summary>
    /// A lifetime lease sponser remote clients
    /// </summary>
    public class RemoteClientSponser : MarshalByRefObject, ISponsor 
    {
        #region Fields
        private string LeaseName; 
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteClientSponser"/> class.
        /// </summary>
        /// <param name="Name">The name.</param>
        public RemoteClientSponser(string Name)
        {
            LeaseName = Name;
        } 
        #endregion

        #region Methods
        #region ISponsor Members

        /// <summary>
        /// Requests a sponsoring client to renew the lease for the specified object.
        /// </summary>
        /// <param name="lease">The lifetime lease of the object that requires lease renewal.</param>
        /// <returns>
        /// The additional lease time for the specified object.
        /// </returns>
        /// <exception cref="T:System.Security.SecurityException">
        /// The immediate caller makes the call through a reference to the interface and does not have infrastructure permission.
        /// </exception>
        /// <PermissionSet>
        /// 	<IPermission class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" Flags="Infrastructure"/>
        /// </PermissionSet>
        public TimeSpan Renewal(ILease lease)
        {
            Console.WriteLine("The lease " + LeaseName + " has asked for renewal at " + DateTime.Now.ToLongTimeString());
            return TimeSpan.FromMinutes(10);
        }

        #endregion 
        #endregion
    }
}
