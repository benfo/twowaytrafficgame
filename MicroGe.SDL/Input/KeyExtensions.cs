using SdlDotNet.Input;

namespace MicroGe.Input
{
    internal static class KeyExtensions
    {
        public static Keys ToTWTKey(this Key key)
        {
            switch (key)
            {
                case Key.UpArrow: return Keys.Up;
                case Key.DownArrow: return Keys.Down;
                case Key.LeftArrow: return Keys.Left;
                case Key.RightArrow: return Keys.Right;
                case Key.Escape: return Keys.Escape;
                default: return Keys.Unknown;
            }
        }
    }
}