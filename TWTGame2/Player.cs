using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using System.Drawing;
using TWTGame.Core.Graphics;

namespace TWTGame
{
    public class Player : TexturedGameObject
    {
        public Vector2 Velocity;

        public Player(Surface playerTexture)
        {
            this.IsDead = false;
            this.Sprite = new Sprite(playerTexture);
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Sprite.Width, this.Sprite.Height);
            }
        }

        public bool IsDead { get; private set; }

        public void Hit()
        {
            this.IsDead = true;
        }
        public void Revive()
        {
            this.IsDead = false;
        }

        public void SetMovement(Vector2 movement)
        {
            if (!this.IsDead)
            {
                this.Velocity = movement;
                this.Position += this.Velocity;
            }
        }
    }
}