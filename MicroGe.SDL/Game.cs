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
            // Calculate time passed since the last time OnTick was called.
            var elapsedTime = _gameTimer.Elapsed;
            _gameTimer.Reset();
            _gameTimer.Start();

            // Call the update and draw methods
            this.Update(elapsedTime);
            this.Draw(elapsedTime);
        }

        protected override void OnExit()
        {
            // Notifies SDL to quit the application
            Events.QuitApplication();
        }

        protected override void OnRun()
        {
            // Starts the Event/Game loop
            Events.Run();
        }

        /// <summary>
        /// Gets or sets the window title.
        /// </summary>
        /// <value>
        /// The window title.
        /// </value>
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