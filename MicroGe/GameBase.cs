using System;
using System.Diagnostics;

namespace MicroGe
{
    public abstract class GameBase : IGame, IDisposable
    {
        private Stopwatch _gameTimer = Stopwatch.StartNew();

        public void Exit()
        {
            this.OnExit();
        }

        public void Run()
        {
            this.OnRun();
        }

        public void Tick()
        {
            var elapsedTime = _gameTimer.Elapsed;
            _gameTimer.Reset();
            _gameTimer.Start();

            this.Update(elapsedTime);
            this.Draw(elapsedTime);
        }

        protected virtual void OnRun()
        {
        }

        protected virtual void Draw(TimeSpan elapsedTime)
        {
        }

        protected virtual void OnExit()
        {
        }

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