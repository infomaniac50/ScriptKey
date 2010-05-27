using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using API;
using SharpFactory;
namespace ScriptKeyCode
{
    /// <summary>
    /// A code wrapper the runs user code when a trigger is matched
    /// </summary>
    internal class MacroCode
    {
        #region Fields
        private GeneralTrigger trigger;
        private DynamicMethodDelegate method;
        private bool issuspended;
        private object[] param;
        private object target;
        #endregion

        #region Events
        /// <summary>
        /// Occurs when the method in this macro returns an error.
        /// </summary>
        public event MacroErrorEventHandler ErrorOccured;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MacroCode"/> class.
        /// </summary>
        /// <param name="Trigger">The trigger that run the method.</param>
        /// <param name="Method">The method to run.</param>
        /// <param name="Target">The target instance.</param>
        public MacroCode(GeneralTrigger Trigger, MethodInfo Method, object Target)
        {
            //set the target instance
            target = Target;
            //set the parameter count to zero since all user code triggers take zero args
            param = new object[0];
            trigger = Trigger;
            method = DynamicMethodDelegateFactory.Create(Method);
            this.IsSuspended = true;
        }
        #endregion

        #region Methods
        //could use the params keyword on this method
        private void Run(EventTypes EventType, GeneralTrigger Trigger)
        {
            try
            {
                //try running the method in the user code.
                method.Invoke(target, param);
            }
            catch (Exception ex)
            {
                //if the user code throws an exception.
                //stop it from doing it again.
                this.IsSuspended  = true;
               
                //notify subscribers an error has occurred.
                ErrorOccured.Invoke(ex);
            }
        }

        //runs when the trigger for this macro fires
        void OnEventFired(EventTypes EventType, GeneralTrigger Trigger)
        {
            //run the user code
            Run(EventType, Trigger);
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets a value indicating whether this instance is suspended.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is suspended; otherwise, <c>false</c>.
        /// </value>
        public bool IsSuspended
        {
            get
            {
                return issuspended;
            }
            set
            {
                if (issuspended != value)
                {
                    issuspended = value;
                    if (issuspended)
                        trigger.EventFired -= new TriggerFiredHandler(OnEventFired);
                    else
                        trigger.EventFired += new TriggerFiredHandler(OnEventFired);
                }
            }
        }
        #endregion
    }
}
