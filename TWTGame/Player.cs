using MicroGe;
using MicroGe.Graphics;
using System.Drawing;

namespace TWTGame
{
    public class Player : TexturedGameObject
    {
        public Vector2 Velocity;

        public Player(Texture playerTexture)
        {
            this.IsDead = false;
            this.Sprite = new Sprite(playerTexture);
        }

        public bool IsDead { get; private set; }

        public void Hit()
        {
            // The player dies
            this.IsDead = true;
        }
        public void Revive()
        {
            // Make the player alive again
            this.IsDead = false;
        }

        public void SetMovement(Vector2 movement)
        {
            // Only set movement if the player is not dead.
            if (!this.IsDead)
            {
                this.Velocity = movement;
                this.Sprite.Position += this.Velocity;
            }
        }
    }
}