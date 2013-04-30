using System;
namespace MicroGe.Graphics
{
    public interface ITexture
    {
        string Name { get; set; }
        int Width { get; }
        int Height { get; }
    }
}
