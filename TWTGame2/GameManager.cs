using System;
using TWTGame.Core.Graphics;
using TWTGame.Core.Input;

namespace TWTGame
{
    public class GameManager : IDisposable
    {
        private IDrawManager _drawManager;
        private IKeyboard _keyboard;

        public GameManager()
        {
            _drawManager = new DrawManager();
            _keyboard = new Keyboard();
        }

        public void Run()
        {
            using (var game = new TwoWayTrafficGame(_drawManager, _keyboard))
            {
                game.Run();
            }
        }

        #region IDisposable Members

        private bool disposed;

        ~GameManager()
        {
            Dispose(false);
        }

        public void Close()
        {
            Dispose();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    IDisposable disposableDrawManager = _drawManager as IDisposable;
                    if (disposableDrawManager != null)
                    {
                        disposableDrawManager.Dispose();
                        _drawManager = null;
                    }
                }
                this.disposed = true;
            }
        }

        #endregion IDisposable Members
    }
}