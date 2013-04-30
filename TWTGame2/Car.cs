using MicroGe;
using MicroGe.Graphics;
using System.Drawing;

namespace TWTGame
{
    public class Car : TexturedGameObject
    {
        public Vector2 Velocity;

        public Car(Vector2 startingPosition, ITexture carTexture)
        {
            this.IsActive = true;
            this.Sprite = new Sprite(carTexture);
            this.Sprite.Position = startingPosition;
        }

        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)this.Sprite.Position.X, (int)this.Sprite.Position.Y, this.Sprite.Width, this.Sprite.Height);
            }
        }

        public bool IsActive { get; set; }

        public void SetMovement(Vector2 movement)
        {
            this.Velocity = movement;
            this.Sprite.Position += this.Velocity;
        }
    }
}