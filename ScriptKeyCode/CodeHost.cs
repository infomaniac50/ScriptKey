using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using API;

using System.Runtime.Remoting;
using System.Runtime.Remoting.Lifetime;

namespace ScriptKeyCode
{
    /// <summary>
    /// Sets up and controls the user code app domain.
    /// </summary>
    public static class CodeHost
    {
        #region Fields
        /// <summary>
        /// Occurs when an error occurs in user code.
        /// </summary>
        public static event MacroErrorEventHandler ErrorOccured;
        private static RemoteServer server;
        private static AppDomain ad;
        private static IScript target;
        private static AppDomainSetup ads;
        private static ILease lease;
        private static RemoteClientSponser sponser;        
        #endregion

        #region Constructors
        static CodeHost()
        {
            //macromanager = new MacroCodeManager();
            server = new RemoteServer();
            //statuswatcher.Created += new FileSystemEventHandler(OnStatusCreated);
            //statuswatcher.Changed += new FileSystemEventHandler(OnStatusChanged);
            //statuswatcher.EnableRaisingEvents = true;
            server.ErrorSent += new MacroErrorEventHandler(server_ErrorSent);
            ads = new AppDomainSetup();
            ads.DisallowBindingRedirects = false;
            ads.ShadowCopyFiles = "true";
            ads.ConfigurationFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;
        }        
        #endregion

        #region Methods
        static void server_ErrorSent(Exception ex)
        {
            if (CodeHost.ErrorOccured != null)
                CodeHost.ErrorOccured.Invoke(ex);
        }

        /// <summary>
        /// Unloads the user code.
        /// </summary>
        private static void Unload()
        {   //app domain might be null so make sure its not
            //and make sure there is an app domain to unload
            if (ad != null)
            {
                lease.Unregister(sponser);
                AppDomain.Unload(ad);
                ad = null;
            }
        }

        /// <summary>
        /// Loads the user code.
        /// </summary>
        /// <param name="AssemblyPath">The assembly path.</param>
        private static void Load()
        {
            if (!File.Exists(AssemblyPath))
                throw new FileNotFoundException("The assembly cannot be found.", AssemblyPath);

            MarshalByRefObject  obj;
            ad = AppDomain.CreateDomain("Sandbox", null, ads);
            obj = (MarshalByRefObject)ad.CreateInstanceAndUnwrap(Assembly.GetExecutingAssembly().FullName, "ScriptKeyCode.RemoteLoader");
            target = (IScript)obj;
            try
            {
                lease = (ILease)obj.GetLifetimeService();
                sponser = new RemoteClientSponser("CodeHost");
                lease.Register(sponser);
                target.Load(AssemblyPath);                                
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex);
            }
        }

        static void OnErrorOccured(Exception ex)
        {
            if (CodeHost.ErrorOccured != null)
                CodeHost.ErrorOccured.Invoke(ex);
        }

        /// <summary>
        /// Starts the user code.
        /// </summary>
        public static void Start()
        {
            try
            {
                Load();
            }
            catch (Exception ex)
            {
                OnErrorOccured(ex);                
            }

            if (ad != null)
            {
                try
                {
                    target.Start();
                }
                catch (Exception ex)
                {
                    OnErrorOccured(ex);                   
                }
            }
        }

        /// <summary>
        /// Stops the user code.
        /// </summary>
        public static void Stop()
        {
            if (ad != null)
            {
                try
                {
                    target.Stop();
                    Unload();
                }
                catch (Exception ex)
                {
                    OnErrorOccured(ex);                    
                }                
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the assembly path.
        /// </summary>
        /// <value>The assembly path.</value>
        internal static string AssemblyPath
        {
            get;
            set;
        } 
        #endregion
    }
}


