using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using API;
using Utility;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;
namespace ScriptKeyCode
{
    /// <summary>
    /// Loads user code into a remote app domain.
    /// </summary>
    public class RemoteLoader : MarshalByRefObject, IScript
    {
        #region Fields
        object target;
        MacroCodeManager macromanager = new MacroCodeManager();
        //Exception lasterror = null;
        //private static readonly string statuspath = Path.Combine(Path.GetTempPath(), "status.dat");
        private RemoteClient client;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteLoader"/> class.
        /// </summary>
        public RemoteLoader()
        {
            client = new RemoteClient();
            macromanager.ErrorOccured += new MacroErrorEventHandler(OnErrorOccured);
        } 
        #endregion

        #region Destructors
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="RemoteLoader"/> is reclaimed by garbage collection.
        /// </summary>
        ~RemoteLoader()
        {
            macromanager.ErrorOccured -= new MacroErrorEventHandler(OnErrorOccured);
        } 
        #endregion




        #region Methods
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

        

        //find the trigger for the method info given
        private static GeneralTrigger GetTrigger(MethodInfo info)
        {
            foreach (object obj in info.GetCustomAttributes(typeof(TriggerAttribute), false))
            {
                //make sure obj is a TriggerAttribute
                if (obj is TriggerAttribute)
                {
                    //if it is a triggerattribute make sure the 
                    if (((TriggerAttribute)obj).EventData != null)
                    {
                        return ((TriggerAttribute)obj).EventData;
                    }
                }
            }
            return null;
        }

        private void OnErrorOccured(Exception ex)
        {
            client.SendException(ex);
        }
        #endregion

        #region IScript Members



        /// <summary>
        /// Loads the specified assembly.
        /// </summary>
        /// <param name="AssemblyPath">The assembly path.</param>
        public void Load(string AssemblyPath)
        {
            target = AppDomain.CurrentDomain.CreateInstanceFromAndUnwrap(AssemblyPath, "UserCode.UserCode");
            if (macromanager.MacrosAreRunning)
                macromanager.StopCode();

            macromanager.ClearMacros();

            foreach (MethodInfo info in target.GetType().GetMethods())
            {
                GeneralTrigger trigger = GetTrigger(info);

                if (trigger != null)
                {
                    MacroCode macro = new MacroCode(trigger, info, target);
                    macromanager.AddMacro(macro);
                }
            }
        }

        /// <summary>
        /// Starts the user code.
        /// </summary>
        public void Start()
        {
            macromanager.StartCode();
        }

        /// <summary>
        /// Stops the user code.
        /// </summary>
        public void Stop()
        {
            macromanager.StopCode();
        }
        #endregion
    }
}
