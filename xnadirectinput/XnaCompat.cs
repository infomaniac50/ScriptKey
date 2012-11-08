using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Microsoft.Xna.Framework
{
    public struct Vector2
    {
        public Vector2(float X, float Y) : this()
        {
            
            this.X = X;
            this.Y = Y;
        }

        public static Vector2 Zero
        {
            get{
                return new Vector2();
            }            
        }

        public float X
        {
            get;
            set;
        }

        public float Y
        {
            get;
            set;
        }
    }
}

namespace Microsoft.Xna.Framework.Input
{
    public enum ButtonState
    {
        Pressed,
        Released
    }
}
