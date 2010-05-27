using System;
using System.Windows.Forms;
using InputLib;
using API;
using ScriptKeyCode;
using Soopah.Xna.Input;
namespace UserCode
{
    [Serializable()]
    public class UserCode
    {
        DirectInputGamepad joy;
        OutputWindow output;

        public UserCode()
        {
            joy = JoystickInput.Hook;
            output = new OutputWindow();
            output.Show();
        }

        [Trigger(Keys.U, InputActions.Press)]
        public void UpdateJoystick()
        {
            output.Clear();

            if (JoystickInput.IsJoystickConnected)
            {
                output.WriteLine("Buttons:");
                output.WriteLine(joy.DiagnosticsButtons);
                output.WriteLine();


            }
            else
                output.WriteLine("Joystick not connected.");

        }

    }
}