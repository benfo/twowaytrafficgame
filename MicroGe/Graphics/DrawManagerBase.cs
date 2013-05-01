using System.Drawing;

namespace MicroGe.Graphics
{
    public abstract class DrawManagerBase<TTexture, TSprite> : IDrawManager
        where TTexture : ITexture
        where TSprite : ISprite
    {
        public abstract Rectangle ScreenSize { get; }

        public abstract void Clear(Color color);

        public abstract void Draw(TSprite sprite);

        public abstract void Draw(TSprite sprite, TextureEffect effect);

        void IDrawManager.Draw(ISprite sprite)
        {
            this.Draw((TSprite)sprite);
        }

        void IDrawManager.Draw(ISprite sprite, TextureEffect effect)
        {
            this.Draw((TSprite)sprite, effect);
        }

        ITexture IDrawManager.LoadTexture(string name, string path)
        {
            return this.LoadTexture(name, path);
        }

        ITexture IDrawManager.LoadTexture(string name, string path, TextureEffect effect)
        {
            return this.LoadTexture(name, path, effect);
        }

        public abstract TTexture LoadTexture(string name, string path);

        public abstract TTexture LoadTexture(string name, string path, TextureEffect effect);

        public abstract void Update();
    }
}