using MicroGe.Graphics;
using MicroGe.Input;
using MicroGe.Services;
using SdlDotNet.Input;
using System;
using System.Drawing;

namespace TWTGame
{
    public class GameplayScreen
    {
        private DrawManager _drawManager;
        private IKeyboard _keyboard;
        private Player _player;
        private Rectangle _playArea;
        private Road _road;
        private IRandomizer _randomizer;
        private float _playerSpeed = 150f;

        public GameplayScreen(DrawManager drawManager, IKeyboard keyboard, IRandomizer randomizer)
        {
            _drawManager = drawManager;
            _keyboard = keyboard;
            _playArea = drawManager.ScreenSize;
            _randomizer = randomizer;

            // Create game objects
            _player = new Player(drawManager.LoadTexture("player", "player.png", TextureEffect.FlippedHorizontal));
            _road = new Road(_player, _drawManager, _randomizer);

            // Set the player starting position
            this.ResetPlayer();
        }

        private void ResetPlayer()
        {
            // Resets the player starting position and make sure the player is alive.
            _player.Sprite.Position = new Vector2(
                _playArea.Width / 2 - _player.Sprite.Width / 2,
                _playArea.Height - _player.Sprite.Height);
            _player.Revive();
        }

        public void Draw()
        {
            // Draw the player to the screen
            _drawManager.Draw((Sprite)_player.Sprite);
            
            // Tell the road to draw
            _road.Draw();
        }

        public void Unload()
        {
            // Unloads resources
            _player.Dispose();
            _road.Unload();
        }

        public void Update(TimeSpan elapsedTime)
        {
            // Tell the road to update
            _road.Update(elapsedTime);

            // Check if the player won or died
            CheckIfPlayerWins();
            CheckIfPlayerDies();

            // Process keyboard input from the player
            CheckForPlayerInput(elapsedTime);
        }

        private void CheckIfPlayerDies()
        {
            if (_player.IsDead)
            {
                // Reset to the starting position
                this.ResetPlayer();
            }
        }

        private void CheckIfPlayerWins()
        {
            if (_player.BoundingBox.Top <= _playArea.Top + 1)
            {
                this.ResetPlayer();

                // Each time the player wins, make the game a little
                // more difficult
                _road.IncreaseLanes(1);
                _road.Lanes.ForEach(lane => lane.IncreaseSpeed());
                _road.Lanes.ForEach(lane => lane.IncreaseTrafficFlow());
            }
        }

        private void CheckForPlayerInput(TimeSpan elapsedTime)
        {
            var movement = Vector2.Zero;

            // Check for keyboard inputs
            if (_keyboard.IsKeyDown(Keys.Up))
            {
                movement += MovementVector.Up;
            }
            if (_keyboard.IsKeyDown(Keys.Down))
            {
                movement += MovementVector.Down;
            }
            if (_keyboard.IsKeyDown(Keys.Left))
            {
                movement += MovementVector.Left;
            }
            if (_keyboard.IsKeyDown(Keys.Right))
            {
                movement += MovementVector.Right;
            }

            // Prevent the player from moving outside of the playing area
            movement = RestrictPlayerMovement(movement);

            // Set movement on the player
            if (movement == Vector2.Zero)
            {
                _player.SetMovement(Vector2.Zero);
            }
            else
            {
                movement *= (float)elapsedTime.TotalSeconds * _playerSpeed;
                _player.SetMovement(movement);
            }
        }

        private Vector2 RestrictPlayerMovement(Vector2 movement)
        {
            // If movement was to be applied, where will the user be
            Rectangle futureBounds = _player.BoundingBox;
            futureBounds.X += (int)movement.X;
            futureBounds.Y += (int)movement.Y;

            // Check for left, right, top and bottom bounds.
            if (futureBounds.Left <= _playArea.Left || futureBounds.Right > _playArea.Right)
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