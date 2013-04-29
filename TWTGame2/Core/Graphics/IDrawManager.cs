using SdlDotNet.Graphics;
using System.Drawing;

namespace TWTGame.Core.Graphics
{
    public interface IDrawManager
    {
        void Clear(Color color);

        Texture LoadTexture(string name, string path);

        Texture LoadTexture(string name, string path, TextureEffect effect);

        void Update();

        Rectangle ScreenSize { get; }

        void Draw(TexturedGameObject gameObject);
    }
}