using SdlDotNet.Core;
using SdlDotNet.Graphics;
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
            Video.WindowCaption = "MicroGe Game";

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

        protected override void OnTick()
        {
            var elapsedTime = _gameTimer.Elapsed;
            _gameTimer.Reset();
            _gameTimer.Start();

            this.Update(elapsedTime);
            this.Draw(elapsedTime);
        }

        protected override void OnExit()
        {
            Events.QuitApplication();
        }

        protected override void OnRun()
        {
            Events.Run();
        }

        public override string WindowTitle
        {
            get
            {
                return Video.WindowCaption;
            }
            set
            {
                Video.WindowCaption = value;
            }
        }
    }
}