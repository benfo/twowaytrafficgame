using System;

namespace MicroGe
{
    /// <summary>
    /// Base game class that provides common methods for 
    /// running, updating and drawing a game.
    /// </summary>
    public abstract class GameBase : IGame, IDisposable
    {
        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        /// <value>
        /// The window title.
        /// </value>
        public virtual string WindowTitle { get; set; }

        /// <summary>
        /// Exits the game.
        /// </summary>
        public void Exit()
        {
            this.OnExit();
        }

        /// <summary>
        /// Runs the game.
        /// </summary>
        public void Run()
        {
            this.OnRun();
        }

        /// <summary>
        /// Updates the game timer and calls update and draw.
        /// </summary>
        public void Tick()
        {
            this.OnTick();
        }

        /// <summary>
        /// Called when the game needs to draw a frame.
        /// </summary>
        /// <param name="elapsedTime">The time passed since the last draw.</param>
        protected virtual void Draw(TimeSpan elapsedTime)
        {
        }

        protected virtual void OnExit()
        {
        }

        protected virtual void OnRun()
        {
        }

        protected virtual void OnTick()
        {
        }

        /// <summary>
        /// Called when the game logic needs to be updated.
        /// </summary>
        /// <param name="elapsedTime">The time passed since the last update.</param>
        protected virtual void Update(TimeSpan elapsedTime)
        {
        }

        #region Disposable

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        #endregion Disposable
    }
}