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
        public UserCode()
        {
            System.Diagnostics.Process.Start("Notepad");
        }

        [Trigger(Keys.H,InputActions.Press)]
        public void SendHelloWorld()
        {
            Keyboard.SendString("Hello World");
        }
    }
}