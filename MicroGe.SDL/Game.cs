using MicroGe;
using SdlDotNet.Core;
using SdlDotNet.Graphics;
using System;
using System.Diagnostics;

namespace MicroGe
{
    public abstract class Game : GameBase
    {
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
        protected override void OnExit()
        {
            Events.QuitApplication();
        }
        protected override void OnRun()
        {
            Events.Run();
        }
    }
}