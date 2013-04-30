using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MicroGe.Graphics
{
    public abstract class DrawManagerBase<TTexture, TSprite> : IDrawManager
        where TTexture : ITexture
        where TSprite : ISprite
    {
        public abstract void Clear(System.Drawing.Color color);

        ITexture IDrawManager.LoadTexture(string name, string path)
        {
            return this.LoadTexture(name, path);
        }

        public abstract TTexture LoadTexture(string name, string path);

        ITexture IDrawManager.LoadTexture(string name, string path, TextureEffect effect)
        {
            return this.LoadTexture(name, path, effect);
        }

        public abstract TTexture LoadTexture(string name, string path, TextureEffect effect);

        public abstract void Update();

        public abstract Rectangle ScreenSize { get; }

        void IDrawManager.Draw(ISprite sprite)
        {
            this.Draw((TSprite)sprite);
        }

        public abstract void Draw(TSprite sprite);
    }
}
