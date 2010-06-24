using System;
using System.Collections.Generic;
using System.Text;
using API;
using System.Windows.Forms;

namespace ScriptKeyCode
{
    /// <summary>
    /// A trigger that fires after a specified amount of time.
    /// </summary>
    public class TimerTrigger : GeneralTrigger
    {
        #region Fields
        private Timer timer;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="TimerTrigger"/> class.
        /// </summary>
        /// <param name="Interval">The interval in milliseconds.</param>
        public TimerTrigger(int Interval) : base(EventTypes.Timer)
        {
            timer = new Timer();
            timer.Interval = Interval; 
            timer.Enabled = true;            
            timer.Tick += new EventHandler(OnTimerTick);
        }       
        #endregion

        #region Destructors
        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="TimerTrigger"/> is reclaimed by garbage collection.
        /// </summary>
        ~TimerTrigger()
        {
            timer.Tick -= new EventHandler(OnTimerTick);
        }
        #endregion

        #region Methods
        void OnTimerTick(object sender, EventArgs e)
        {
            base.OnEventTriggered(EventTypes.Timer, this);
        } 

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return "Timer interval: " + timer.Interval.ToString();
        }

        ///// <summary>
        ///// Parses the specified event data.
        ///// </summary>
        ///// <param name="EventData">The event data.</param>
        ///// <returns></returns>
        //public static TimerTrigger Parse(string EventData)
        //{
        //    double number;

        //    if (Information.IsNumeric(EventData.Trim()))
        //        number = double.Parse(EventData.Trim());
        //    else
        //        throw new MalformedEventDataException(EventData, "The argument in " + EventData + " is not number");

        //    return new TimerTrigger((int)number);
        //}
        #endregion
    }
}
