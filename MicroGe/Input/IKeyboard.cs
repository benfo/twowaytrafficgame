namespace MicroGe.Input
{
    public interface IKeyboard
    {
        bool IsKeyDown(Keys key);

        bool IsKeyUp(Keys key);
    }
}