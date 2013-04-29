using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using System.Drawing;
using TWTGame.Core.Graphics;

namespace TWTGame
{
    public class Car : TexturedGameObject
    {
        public Vector2 Velocity;

        public Car(Vector2 startingPosition, Texture carTexture)
        {
            this.IsActive = true;
            this.Position = startingPosition;
            this.Sprite = new Sprite(carTexture.Surface);
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)this.Position.X, (int)this.Position.Y, this.Sprite.Width, this.Sprite.Height);
            }
        }

        public bool IsActive { get; set; }

        public void SetMovement(Vector2 movement)
        {
            this.Velocity = movement;
            this.Position += this.Velocity;
        }
    }
}