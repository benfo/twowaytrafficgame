using SdlDotNet.Graphics.Sprites;
using TWTGame.Core.Graphics;

namespace TWTGame
{
    public abstract class TexturedGameObject : GameObject
    {
        public Vector2 Position;

        public Sprite Sprite { get; protected set; }

        public void Unload()
        {
            if (this.Sprite != null)
            {
                this.Sprite.Dispose();
                this.Sprite = null;
            }
        }
    }
}