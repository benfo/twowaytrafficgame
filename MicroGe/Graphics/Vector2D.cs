using System;

namespace MicroGe.Graphics
{
    /// <summary>
    /// Defines a vector with two values.
    /// </summary>
    public struct Vector2 : IEquatable<Vector2>
    {
        public float X;
        public float Y;
        private static Vector2 vectorZero = new Vector2(0f, 0f);

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

        public static Vector2 Zero
        {
            get { return vectorZero; }
        }

        public static Vector2 operator -(Vector2 value)
        {
            value.X = -value.X;
            value.Y = -value.Y;
            return value;
        }

        public static Vector2 operator -(Vector2 value1, Vector2 value2)
        {
            value1.X -= value2.X;
            value1.Y -= value2.Y;
            return value1;
        }

        public static bool operator !=(Vector2 value1, Vector2 value2)
        {
            return value1.X != value2.X || value1.Y != value2.Y;
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

        public static Vector2 operator +(Vector2 value1, Vector2 value2)
        {
            value1.X += value2.X;
            value1.Y += value2.Y;
            return value1;
        }

        public static bool operator ==(Vector2 value1, Vector2 value2)
        {
            return value1.X == value2.X && value1.Y == value2.Y;
        }

        public bool Equals(Vector2 other)
        {
            return (X == other.X) && (Y == other.Y);
        }

        public override bool Equals(object obj)
        {
            if (obj is Vector2)
            {
                return Equals((Vector2)obj);
            }

            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() + Y.GetHashCode();
        }
    }
}