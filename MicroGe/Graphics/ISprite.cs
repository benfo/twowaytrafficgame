namespace MicroGe.Graphics
{
    /// <summary>
    /// Represents a sprite object that can be drawn to the screen.
    /// </summary>
    public interface ISprite
    {
        Vector2 Position { get; set; }

        ITexture Texture { get; }

        int Width { get; }

        int Height { get; }

        int X { get; set; }

        int Y { get; set; }
    }
}