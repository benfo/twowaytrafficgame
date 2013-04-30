using System;
namespace MicroGe.Graphics
{
    public interface ISprite
    {
        int Height { get; }
        ITexture Texture { get; }
        int Width { get; }
        Vector2 Position { get; set; }
    }
}
