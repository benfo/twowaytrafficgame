using MicroGe;
using MicroGe.Graphics;
using System.Drawing;

namespace TWTGame
{
    public class Car : TexturedGameObject
    {
        public Vector2 Velocity;

        public Car(Vector2 startingPosition, Texture carTexture)
        {
            this.IsActive = true;
            this.Sprite = new Sprite(carTexture);
            this.Sprite.Position = startingPosition;
        }

        public bool IsActive { get; private set; }

        public void Activate()
        {
            this.IsActive = true;
        }

        public void Deactivate()
        {
            this.IsActive = false;
        }

        public void SetMovement(Vector2 movement)
        {
            this.Velocity = movement;
            this.Sprite.Position += this.Velocity;
        }
    }
}