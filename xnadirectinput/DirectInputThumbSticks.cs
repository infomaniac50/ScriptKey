using System;
using Microsoft.DirectX.DirectInput;
using Microsoft.Xna.Framework;

namespace Soopah.Xna.Input
{
	/// <summary>
	/// A struct offering the current positions of as many as 3 thumbsticks on a PC gamepad or joystick
	/// </summary>
	/// <remarks>
	/// For unusual joysticks, these "thumbsticks" may be whatever the hardware-designer imagined;
	/// for example, Right.Y might be a jet-throttle and Right.X might be the rotational position of a steering wheel
	/// In other words, being in the list of Gamepads doesn't mean it looks anything like a Gamepad
	/// </remarks>
	public struct DirectInputThumbSticks
	{
        /// <summary>
        /// Gets or sets the left thumbstick.
        /// </summary>
        /// <value>The left thumbstick.</value>
        public Vector2 Left
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets or sets the right thumbstick.
        /// </summary>
        /// <value>The right thumbstick.</value>
        public Vector2 Right
        {
            get;
            private set;

        }
        /// <summary>
        /// Gets or sets the third thumbstick.
        /// </summary>
        /// <value>The third thumbstick.</value>
        public Vector2 Third
        {
            get;
            private set;
        }
		//public Microsoft.Xna.Framework.Vector2 Fourth;

        /// <summary>
        /// Gets or sets a value indicating whether this device has a left thumbstick.
        /// </summary>
        /// <value><c>true</c> if this device has a left thumbstick; otherwise, <c>false</c>.</value>
        public bool HasLeft
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether this device has a right thumbstick.
        /// </summary>
        /// <value><c>true</c> if this device has a right thumbstick; otherwise, <c>false</c>.</value>
        public bool HasRight
        {
            get;
            private set;
        }
        /// <summary>
        /// Gets or sets a value indicating whether this device has a third thumbstick.
        /// </summary>
        /// <value><c>true</c> if this device has a third thumbstick; otherwise, <c>false</c>.</value>
        public bool HasThird
        {
            get;
            private set;
        }
		//public bool HasFourth;

		const float center = 32767.5f;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectInputThumbSticks"/> struct.
        /// </summary>
        /// <param name="device">The device.</param>
		public DirectInputThumbSticks(Device device) : this()
		{
			JoystickState t = device.CurrentJoystickState;

			HasLeft = false;
			Left = Vector2.Zero;
			HasRight = false;
			Right = Vector2.Zero;
			HasThird = false;
			Third = Vector2.Zero;

			if (device.Caps.NumberAxes > 0)
			{
				HasLeft = true;
				Left = new Vector2((t.X - center) / center, (t.Y - center) / center);

				if (device.Caps.NumberAxes > 2)
				{
					HasRight = true;
					Right = new Vector2((t.Rz - center) / center, (t.Z - center) / center);

					if (device.Caps.NumberAxes > 4)
					{
						HasThird = true;
						Third = new Vector2((t.Rx - center) / center, (t.Ry - center) / center);
					}
				}
			}
		}
	}
}
