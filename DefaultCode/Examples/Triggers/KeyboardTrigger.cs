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
        OutputWindow output;

        public UserCode()
        {
            output = new OutputWindow();
            output.Show();
        }

        [Trigger(Keys.A,InputActions.Press)]
        public void AKeyPressed()
        {
            output.WriteLine("The A key was pressed.");
        }

        [Trigger(Keys.A,InputActions.Up)]
        public void AKeyUp()
        {
            output.WriteLine("The A key is up.");
        }

        [Trigger(Keys.A,InputActions.Down)]
        public void AKeyDown()
        {
            output.WriteLine("The A key is down.");
        }
    }
}