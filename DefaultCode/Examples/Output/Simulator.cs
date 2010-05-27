using System;
using System.Windows.Forms;
using InputLib;
using API;
using ScriptKeyCode;
namespace UserCode
{
    [Serializable()]
    public class UserCode
    {
        public UserCode()
        {
            System.Diagnostics.Process.Start("Notepad");
        }

        [Trigger(Keys.H,InputActions.Press)]
        public void SendHelloWorld()
        {
            MouseSimulator.SendKey(
        }
    }
}