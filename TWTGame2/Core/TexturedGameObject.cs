using SdlDotNet.Graphics.Sprites;
using System;
using TWTGame.Core.Graphics;

namespace TWTGame
{
    public abstract class TexturedGameObject : GameObject, IDisposable
    {
        public Vector2 Position;

        public Sprite Sprite { get; protected set; }

        public void Dispose()
        {
            if (this.Sprite != null)
            {
                this.Sprite.Dispose();
                this.Sprite = null;
            }
        }
    }
}