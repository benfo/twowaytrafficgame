using System;
using MicroGe.Graphics;
using System.Drawing;

namespace MicroGe
{
    public abstract class TexturedGameObject : GameObject, IDisposable
    {
        public ISprite Sprite { get; protected set; }

        public void Dispose()
        {
            if (this.Sprite != null && this.Sprite is IDisposable)
            {
                ((IDisposable)this.Sprite).Dispose();                
                this.Sprite = null;
            }
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)this.Sprite.Position.X, (int)this.Sprite.Position.Y, this.Sprite.Width, this.Sprite.Height);
            }
        }
    }
}