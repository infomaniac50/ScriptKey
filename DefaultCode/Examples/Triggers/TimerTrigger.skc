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
        private OutputWindow output = new OutputWindow();

        public UserCode()
        {
            output = new OutputWindow();
            output.Show();
        }

        [Trigger(1000)]
        public void TimerElapsed()
        {
            output.WriteLine("The timer fired at " + DateTime.Now.ToShortTimeString());
        }
    }
}