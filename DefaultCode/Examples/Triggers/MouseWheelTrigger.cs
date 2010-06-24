using System;
using System.Windows.Forms;
using API;
using API.Output;
using ScriptKeyCode;
namespace UserCode
{
    [Serializable()]
    public class UserCode
    {
        private OutputForm output;

        public UserCode()
        {
            output = new OutputForm();
            output.Show();
        }

        [Trigger(WheelActions.Up)]
        public void MouseWheelUp()
        {
            output.WriteLine("Mouse wheel was rolled up.");
        }

        [Trigger(WheelActions.Down)]
        public void MouseWheelDown()
        {
            output.WriteLine("Mouse wheel was rolled down.");
        }       
    }
}