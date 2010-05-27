using System;
using System.Collections.Generic;

using System.Text;
using System.Text.RegularExpressions;
using Utility;
namespace ScriptKeyCode
{
    /// <summary>
    /// Parses event data from trigger attributes
    /// </summary>
    internal static class EventDataParser
    {
        #region Fields
        //event data validator
        //tests for multiple keys and exactly one action       
        private static Regex eventdatavalidator = new Regex(@"\A(?:\w+\+?)*,?(?:up|down|press){1}\Z", RegexOptions.IgnoreCase);
        #endregion

       #region Methods
        /// <summary>
        /// Validates the event data.
        /// </summary>
        /// <param name="EventData">The event data.</param>
        /// <returns></returns>
        public static bool ValidateEventData(string EventData)
        {
            return eventdatavalidator.IsMatch(EventData);
        }

        private static void ThrowMalformedEventDataException(string EventData)
        {
            throw new MalformedEventDataException(EventData);
        }

        /// <summary>
        /// Gets the key events.
        /// </summary>
        /// <param name="EventData">The event data.</param>
        /// <returns>Returns the separated key events</returns>
        public static string[] GetKeys(string EventData)
        {
            if (!ValidateEventData(EventData))
                ThrowMalformedEventDataException(EventData);

            //setup the default return value
            string[] result = new string[0];

            //if the string has keys separate them from the event data and each other
            //eventdata must always have an action so we always split by comma first
            if (EventData.Contains(","))
                result = EventData.Split(',')[0].Split('+');

            return result;
        }

        /// <summary>
        /// Gets the wheel actions.
        /// </summary>
        /// <param name="EventData">The event data.</param>
        /// <returns></returns>
        public static WheelActions GetWheelAction(string EventData)
        {
            //get the input action
            InputActions action = GetInputAction(EventData);

            //decide which action it is
            //wheel actions dont support press so throw if it is.
            switch (action)
            {
                case InputActions.Press:
                    throw new InvalidCastException("No valid wheel action exists for " + action.ToString());
                case InputActions.Down:
                    return WheelActions.Down;
                case InputActions.Up:
                    return WheelActions.Up;
                default:
                    throw new InvalidCastException();
            }
        }
        
        /// <summary>
        /// Gets the action.
        /// </summary>
        /// <param name="EventData">The event data.</param>
        /// <returns></returns>
        public static InputActions GetInputAction(string EventData)
        {
            if (!ValidateEventData(EventData))
                ThrowMalformedEventDataException(EventData);

            string actionstring;

            //if the event data has keys and an action 
            if (EventData.Contains(","))
            {
                //separate the keys and the action
                //actions always come last and only one action is allowed
                //commas delineate actiosn
                actionstring = EventData.Split(',')[1];
            }
            else
            {
                //else just copy the string because no keys are present
                actionstring = EventData;
            }

            //remove any whitespaces
            actionstring = actionstring.Trim().ToLower();

            //capitalize the string
            actionstring = Formatting.CapitalizeString(actionstring);

            //get the enum value that matches the action string
            InputActions action = (InputActions)System.Enum.Parse(typeof(InputActions), actionstring);

            return action;
        }
        #endregion 
    }
}
