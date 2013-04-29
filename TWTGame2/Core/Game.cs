﻿using SdlDotNet.Core;
using SdlDotNet.Graphics;
using System;
using System.Diagnostics;

namespace TWTGame.Core
{
    public abstract class Game : IDisposable
    {
        private bool _disposed;
        private Stopwatch _gameTimer = Stopwatch.StartNew();

        public Game()
        {
            // Setup video
            Video.WindowIcon();
            Video.SetVideoMode(800, 600);

            // Setup events
            Events.Tick += (sender, args) =>
            {
                this.Tick();
            };

            Events.Quit += (sender, args) =>
            {
                this.Exit();
            };
        }

        public void Exit()
        {
            this.OnExit();
            Events.QuitApplication();
        }

        public void Run()
        {
            Events.Run();
        }

        public void Tick()
        {
            var elapsedTime = _gameTimer.Elapsed;
            _gameTimer.Reset();
            _gameTimer.Start();

            this.Update(elapsedTime);
            this.Draw(elapsedTime);
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

        ~Game()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
            _disposed = true;
        }

        #endregion Disposable
    }
}