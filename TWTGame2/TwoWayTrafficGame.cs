using SdlDotNet.Input;
using System;
using System.Drawing;
using MicroGe;
using MicroGe.Graphics;
using MicroGe.Input;
using MicroGe.Bootstrapper;

namespace TWTGame
{
    public class TwoWayTrafficGame : Game
    {
        private IDrawManager _drawManager;
        private GameplayScreen _gameplayScreen;
        private IKeyboard _keyboard;

        public TwoWayTrafficGame(IDrawManager drawManager, IKeyboard keyboard)
        {
            _drawManager = drawManager;
            _keyboard = keyboard;
            _gameplayScreen = DependencyResolver.Current.GetService<GameplayScreen>();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _gameplayScreen.Unload();
            }
            base.Dispose(disposing);
        }

        protected override void Draw(TimeSpan elapsedTime)
        {
            _drawManager.Clear(Color.CornflowerBlue);
            _gameplayScreen.Draw();
            _drawManager.Update();
        }

        protected override void Update(TimeSpan elapsedTime)
        {
            if (_keyboard.IsKeyDown(Keys.Escape))
            {
                this.Exit();
                return;
            }

            _gameplayScreen.Update(elapsedTime);
        }
    }
}