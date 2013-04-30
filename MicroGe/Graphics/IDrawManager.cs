using System.Drawing;

namespace MicroGe.Graphics
{
    public interface IDrawManager
    {
        void Clear(Color color);

        ITexture LoadTexture(string name, string path);

        ITexture LoadTexture(string name, string path, TextureEffect effect);

        void Update();

        Rectangle ScreenSize { get; }

        void Draw(ISprite sprite);

        void Draw(ISprite sprite, TextureEffect effect);
    }
}