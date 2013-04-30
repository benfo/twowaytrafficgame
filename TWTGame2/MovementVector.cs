using MicroGe.Graphics;
namespace TWTGame
{
    public static class MovementVector
    {
        private static Vector2 _vectorDown = new Vector2(0, 1);
        private static Vector2 _vectorLeft = new Vector2(-1, 0);
        private static Vector2 _vectorRight = new Vector2(1, 0);
        private static Vector2 _vectorUp = new Vector2(0, -1);

        public static Vector2 Down
        {
            get { return _vectorDown; }
        }

        public static Vector2 Left
        {
            get { return _vectorLeft; }
        }

        public static Vector2 Right
        {
            get { return _vectorRight; }
        }

        public static Vector2 Up
        {
            get { return _vectorUp; }
        }
    }
}