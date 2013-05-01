using SdlDotNet.Core;
using SdlDotNet.Graphics;

namespace MicroGe
{
    public abstract class Game : GameBase
    {
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