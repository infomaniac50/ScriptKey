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
        OutputForm output;

        public UserCode()
        {
            output = new OutputForm();
            output.Show();
        }

        [Trigger(MouseButtons.Left,InputActions.Press)]
        public void SayHelloWorld()
        {
            output.WriteLine("Hello World");
        }


    }
}