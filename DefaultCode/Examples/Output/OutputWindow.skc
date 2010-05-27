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
        private OutputWindow output = new OutputWindow();

        [Trigger(Keys.W, InputActions.Up)]
        public void SayHello()
        {
            output.WriteLine(AppDomain.CurrentDomain.FriendlyName);
        }

        [Trigger(Keys.S, InputActions.Up)]
        public void ShowOutputWindow()
        {
            output.Show();
        }

        [Trigger(Keys.H, InputActions.Up)]
        public void HideOutputWindow()
        {
            output.Hide();
        }
    }
}