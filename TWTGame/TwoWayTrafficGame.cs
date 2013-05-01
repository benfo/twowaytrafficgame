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
            base.WindowTitle = "Two Way Traffic Game";

            _drawManager = drawManager;
            _keyboard = keyboard;

            // Use the IoC container to create an instance of the gameplay screen.
            _gameplayScreen = DependencyResolver.Current.GetService<GameplayScreen>();
        }

        protected override void Draw(TimeSpan elapsedTime)
        {
            // Clear the screen
            _drawManager.Clear(Color.CornflowerBlue);
            
            // Tell the gameplay screen to draw
            _gameplayScreen.Draw();

            // Now actually refresh the drawing on the screen
            _drawManager.Update();
        }

        protected override void Update(TimeSpan elapsedTime)
        {
            // Exit the game when the player press escape
            if (_keyboard.IsKeyDown(Keys.Escape))
            {
                this.Exit();
                return;
            }

            // Tell the gameplay screen to update game logic.
            _gameplayScreen.Update(elapsedTime);
        }
        
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Unload resources
                _gameplayScreen.Unload();
            }
            base.Dispose(disposing);
        }
    }
}