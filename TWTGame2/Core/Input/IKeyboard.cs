using SdlDotNet.Input;

namespace TWTGame.Core.Input
{
    public interface IKeyboard
    {
        bool IsKeyDown(Key key);

        bool IsKeyUp(Key key);
    }
}