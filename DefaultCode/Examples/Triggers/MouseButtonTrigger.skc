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

        [Trigger(MouseButtons.Left,InputActions.Press)]
        public void SayHelloWorld()
        {
            output.WriteLine("Hello World");
        }


    }
}