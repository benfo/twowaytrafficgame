﻿using MicroGe;
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
                this.Sprite.Position += this.Velocity;
            }
        }
    }
}