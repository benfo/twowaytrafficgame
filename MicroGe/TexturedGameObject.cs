using System;
using MicroGe.Graphics;

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
    }
}