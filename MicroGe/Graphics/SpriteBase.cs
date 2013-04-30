using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroGe.Graphics
{
    public abstract class SpriteBase : ISprite, IDisposable
    {
        public SpriteBase(ITexture texture)
        {
            this.Texture = texture;
        }

        public Vector2 _position;
        public Vector2 Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
            }
        }

        public ITexture Texture { get; private set; }

        public abstract int X { get; set; }
        public abstract int Y { get; set; }
        public abstract int Width { get; }
        public abstract int Height { get; }

        #region IDisposable

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion IDisposable
    }
}
