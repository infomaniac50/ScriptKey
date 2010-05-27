//using System;
//using System.Collections.Generic;
//using System.Text;
//using API;
//namespace ScriptKeyCode
//{
//    /// <summary>
//    /// Builds triggers from event data.
//    /// </summary>
//    public static class TriggerFactory
//    {
//        /// <summary>
//        /// Builds a trigger.
//        /// </summary>
//        /// <param name="EventType">Type of the event.</param>
//        /// <param name="EventData">The event data.</param>
//        /// <returns></returns>
//        public static GeneralTrigger BuildTrigger(EventTypes EventType, string EventData)
//        {
//            switch (EventType)
//            {
//                case EventTypes.Keyboard:
//                    return KeyboardTrigger.Parse(EventData);                    
//                case EventTypes.MouseButton:
//                    return MouseButtonTrigger.Parse(EventData);
//                case EventTypes.MouseWheel:
//                    return MouseWheelTrigger.Parse(EventData);
//                case EventTypes.Timer:
//                    return TimerTrigger.Parse(EventData);
//                default:
//                    return null;
//            }
//        }        
//    }
//}
