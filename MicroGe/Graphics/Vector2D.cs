using System;
using System.Text;
using System.Globalization;


namespace MicroGe.Graphics
{
    public struct Vector2
    {
        private static Vector2 vectorZero = new Vector2(0f, 0f);

        public float X;
        public float Y;

        public static Vector2 Zero
        {
            get { return vectorZero; }
        }

        public Vector2(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector2(float value)
        {
            this.X = value;
            this.Y = value;
        }

        public static Vector2 operator -(Vector2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            return value;
        }

        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }


        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }


        public static Vector2 operator *(Vector2 value1, Vector2 value2)
        {
            value1.X *= value2.X;
            value1.Y *= value2.Y;
            return value1;
        }


        public static Vector2 operator *(Vector2 value, float scaleFactor)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }

        public static Vector2 operator *(float scaleFactor, Vector2 value)
        {
            value.X *= scaleFactor;
            value.Y *= scaleFactor;
            return value;
        }

        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            return value1.X == value2.X && value1.Y == value2.Y;
        }

        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            return value1.X != value2.X || value1.Y != value2.Y;
        }
    }
}
