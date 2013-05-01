namespace MicroGe.Graphics
{
    /// <summary>
    /// Represents a texture that can be used with a
    /// sprite, or drawn to the screen.
    /// </summary>
    public interface ITexture
    {
        int Height { get; }

        string Name { get; set; }

        int Width { get; }
    }
}