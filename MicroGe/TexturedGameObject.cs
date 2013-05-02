using MicroGe.Graphics;
using System;
using System.Drawing;

namespace MicroGe
{
    /// <summary>
    /// Base class for all textured game objects that can be drawn to the screen.
    /// </summary>
    public abstract class TexturedGameObject : GameObject, IDisposable
    {
        /// <summary>
        /// Gets the bounding box for this instance.
        /// </summary>
        /// <value>
        /// The bounding box.
        /// </value>
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)this.Sprite.Position.X, (int)this.Sprite.Position.Y, this.Sprite.Width, this.Sprite.Height);
            }
        }

        /// <summary>
        /// Gets or sets the sprite related to this instance.
        /// </summary>
        /// <value>
        /// The sprite.
        /// </value>
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