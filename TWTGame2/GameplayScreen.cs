using SdlDotNet.Input;
using System;
using System.Drawing;
using TWTGame.Core;
using TWTGame.Core.Graphics;
using TWTGame.Core.Input;
using TWTGame.Core.Services;

namespace TWTGame
{
    public class GameplayScreen
    {
        private IDrawManager _drawManager;
        private IKeyboard _keyboard;
        private Player _player;
        private Rectangle _playArea;
        private Road _carManager;
        private IRandomizer _randomizer;

        public GameplayScreen(IDrawManager drawManager, IKeyboard keyboard, IRandomizer randomizer)
        {
            _drawManager = drawManager;
            _keyboard = keyboard;
            _playArea = drawManager.ScreenSize;

            _player = new Player(drawManager.LoadTexture("player", "player.png", TextureEffect.FlippedHorizontal));
            _randomizer = randomizer;

            _carManager = new Road(_drawManager, _keyboard, _player, _randomizer);

            this.ResetPlayer();
        }

        private void ResetPlayer()
        {
            _player.Position = new Vector2(
                _playArea.Width / 2 - _player.Sprite.Width / 2,
                _playArea.Height - _player.Sprite.Height);
            _player.Revive();
        }

        public void Draw()
        {
            _drawManager.Draw(_player);
            _carManager.Draw();
        }

        public void Unload()
        {
            _player.Dispose();
        }

        public void Update(TimeSpan elapsedTime)
        {
            _carManager.Update(elapsedTime);

            CheckIfPlayerWins();
            CheckIfPlayerDies();

            CheckForPlayerInput(elapsedTime);
        }

        private void CheckIfPlayerDies()
        {
            if (_player.IsDead)
            {
                this.ResetPlayer();
            }
        }

        private void CheckIfPlayerWins()
        {
            if (_player.BoundingBox.Top <= _playArea.Top + 1)
            {
                this.ResetPlayer();

                //_carManager.Lanes.ForEach(lane => lane.IncreaseTrafficFlow());
                _carManager.Lanes.ForEach(lane => lane.IncreaseSpeed());
            }
        }

        private void CheckForPlayerInput(TimeSpan elapsedTime)
        {
            var movement = Vector2.Zero;

            // Check for keyboard inputs
            if (_keyboard.IsKeyDown(Key.UpArrow))
            {
                movement += MovementVector.Up;
            }
            if (_keyboard.IsKeyDown(Key.DownArrow))
            {
                movement += MovementVector.Down;
            }
            if (_keyboard.IsKeyDown(Key.LeftArrow))
            {
                movement += MovementVector.Left;
            }
            if (_keyboard.IsKeyDown(Key.RightArrow))
            {
                movement += MovementVector.Right;
            }

            // Prevent the playe from moving outside of the playing area
            movement = RestrictPlayerMovement(movement);

            // Set movement on the player
            if (movement == Vector2.Zero)
            {
                _player.SetMovement(Vector2.Zero);
            }
            else
            {
                movement *= (float)elapsedTime.TotalSeconds * 150f;
                _player.SetMovement(movement);
            }
        }

        private Vector2 RestrictPlayerMovement(Vector2 movement)
        {
            // If movement was to be applied, where will the user be
            Rectangle futureBounds = _player.BoundingBox;
            futureBounds.X += (int)movement.X;
            futureBounds.Y += (int)movement.Y;

            if (futureBounds.Left <= _playArea.Left || futureBounds.Right >= _playArea.Right)
            {
                movement.X = 0;
            }
            if (futureBounds.Top <= _playArea.Top || futureBounds.Bottom >= _playArea.Bottom)
            {
                movement.Y = 0;
            }

            return movement;
        }
    }
}