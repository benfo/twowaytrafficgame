using SdlDotNet.Graphics;
using System.Drawing;

namespace TWTGame.Core.Graphics
{
    public interface IDrawManager
    {
        void Clear(Color color);

        Surface LoadTexture(string name, string path);

        Surface LoadTexture(string name, string path, TextureEffect effect);

        void Update();

        Rectangle ScreenSize { get; }

        void Draw(TexturedGameObject gameObject);
    }
}