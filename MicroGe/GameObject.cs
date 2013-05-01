using System;

namespace MicroGe
{
    /// <summary>
    /// Base class for all MicroGe game objects.
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// Called when the game logic needs to be updated.
        /// </summary>
        /// <param name="elapsedTime">The time passed since the last update.</param>
        public virtual void Update(TimeSpan elapsedTime)
        {
        }
    }
}