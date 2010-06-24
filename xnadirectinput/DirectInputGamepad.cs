using System;
using System.Collections.Generic;

using Microsoft.DirectX.DirectInput;
using Microsoft.Xna.Framework.Input;

namespace Soopah.Xna.Input
{
    /// <summary>
    /// A class for accessing the DirectX Joystick
    /// </summary>
    public class DirectInputGamepad
    {
		private static List<DirectInputGamepad> gamepads;
        /// <summary>
        /// Gets the gamepads.
        /// </summary>
        /// <value>The gamepads.</value>
		public static List<DirectInputGamepad> Gamepads
		{
			get
			{
				if (gamepads == null)
					ReloadGamepads();

				return gamepads;
			}
            protected set
            {
                gamepads = value;
            }
		}

        /// <summary>
        /// Normally for internal use only; call if user has attached new Gamepads,
        /// or detached Gamepads you want discarded
        /// Otherwise, loaded once on first Gamepad request and does not reflect changes in gamepad attachment
        /// TODO: Do this better
        /// </summary>
		public static void ReloadGamepads()
		{
			// gamepads generally misidentified as Joysticks in DirectInput... get both
			DeviceList gamepadInstanceList = Manager.GetDevices(DeviceType.Gamepad, EnumDevicesFlags.AttachedOnly);
			DeviceList joystickInstanceList = Manager.GetDevices(DeviceType.Joystick, EnumDevicesFlags.AttachedOnly);

			gamepads = new List<DirectInputGamepad>(gamepadInstanceList.Count + joystickInstanceList.Count);

			foreach (DeviceInstance deviceInstance in gamepadInstanceList)
			{
				DirectInputGamepad gamepad = new DirectInputGamepad(deviceInstance.InstanceGuid);
				gamepads.Add(gamepad);
			}
			foreach (DeviceInstance deviceInstance in joystickInstanceList)
			{
				DirectInputGamepad gamepad = new DirectInputGamepad(deviceInstance.InstanceGuid);
				gamepads.Add(gamepad);
			}
		}



		//protected Device device;
        /// <summary>
        /// Gets the device.
        /// </summary>
        /// <value>The device.</value>
        public Device Device
        {
            get;
            protected set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectInputGamepad"/> class.
        /// </summary>
        /// <param name="gamepadInstanceGuid">The gamepad instance GUID.</param>
		protected DirectInputGamepad(Guid gamepadInstanceGuid)
		{
			Device = new Device(gamepadInstanceGuid);
			Device.SetDataFormat(DeviceDataFormat.Joystick);
			Device.Acquire();			
		}

        /// <summary>
        /// Gets the thumb sticks.
        /// </summary>
        /// <value>The thumb sticks.</value>
		public DirectInputThumbSticks ThumbSticks
		{
			get { return new DirectInputThumbSticks(Device); }
		}

        /// <summary>
        /// Gets the DPad.
        /// </summary>
        /// <value>The DPad.</value>
		public DirectInputDPad DPad
		{
			get
			{
				JoystickState t = Device.CurrentJoystickState;
				return new DirectInputDPad(t.GetPointOfView()[0]);	// note that there could be a total of 4 DPads on the PC
			}
		}

        /// <summary>
        /// Gets the buttons.
        /// </summary>
        /// <value>The buttons.</value>
		public DirectInputButtons Buttons
		{
			get { return new DirectInputButtons(Device); }
		}

		#region Diagnostics
        /// <summary>
        /// Gets the thumb sticks values.
        /// </summary>
        /// <value>The thumb sticks values.</value>
		public string DiagnosticsThumbSticks
		{
			get
			{
				return
					"X" + Math.Round(ThumbSticks.Left.X, 4) +
					" Y" + Math.Round(ThumbSticks.Left.Y, 4) +
					" X" + Math.Round(ThumbSticks.Right.X, 4) +
					" Y" + Math.Round(ThumbSticks.Right.Y, 4);
			}
		}

        /// <summary>
        /// Gets the raw gamepad data.
        /// </summary>
        /// <value>The raw gamepad data.</value>
		public string DiagnosticsRawGamepadData
		{
			get
			{
				return
					"X" + Device.CurrentJoystickState.X +
					" Y" + Device.CurrentJoystickState.Y +
					" Z" + Device.CurrentJoystickState.Z +
					" Rx" + Device.CurrentJoystickState.Rx +
					" Ry" + Device.CurrentJoystickState.Ry +
					" Rz" + Device.CurrentJoystickState.Rz +
					" pov[0]" + Device.CurrentJoystickState.GetPointOfView()[0];
			}
		}

        /// <summary>
        /// Gets the button values.
        /// </summary>
        /// <value>The button values.</value>
		public string DiagnosticsButtons
		{
			get
			{
				System.Text.StringBuilder sb = new System.Text.StringBuilder();

				int i = 0;
				foreach (ButtonState bs in Buttons.List)
				{
					sb.Append(i);
					sb.Append("=");
					sb.Append((bs == ButtonState.Pressed ? "1" : "0"));
					sb.Append(" ");
					i++;
				}

				return sb.ToString();
			}
		}
		#endregion
	}
}
