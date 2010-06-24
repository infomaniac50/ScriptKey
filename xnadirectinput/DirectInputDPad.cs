using System;
using Microsoft.Xna.Framework.Input;

namespace Soopah.Xna.Input
{
    /// <summary>
    /// A stucture containing the state of the DPad.
    /// </summary>
	public struct DirectInputDPad
	{
        /// <summary>
        /// The DPad up state.
        /// </summary>
		public ButtonState Up;
        /// <summary>
        /// The DPad right state.
        /// </summary>
		public ButtonState Right;
        /// <summary>
        /// The DPad down state.
        /// </summary>
		public ButtonState Down;
        /// <summary>
        /// The DPad left state.
        /// </summary>
		public ButtonState Left;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectInputDPad"/> struct.
        /// </summary>
        /// <param name="direction">The direction.</param>
		public DirectInputDPad(int direction)
		{
			Up = ButtonState.Released;
			Right = ButtonState.Released;
			Down = ButtonState.Released;
			Left = ButtonState.Released;

			if (direction == -1)
				return;

			if (direction > 27000 || direction < 9000)
				Up = ButtonState.Pressed;

			if (0 < direction && direction < 18000)
				Right = ButtonState.Pressed;

			if (9000 < direction && direction < 27000)
				Down = ButtonState.Pressed;

			if (18000 < direction)
				Left = ButtonState.Pressed;
		}
	}
}
