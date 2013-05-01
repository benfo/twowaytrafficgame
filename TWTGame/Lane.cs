using MicroGe.Graphics;
using MicroGe.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace TWTGame
{
    public class Lane
    {
        private Texture _carTexture;
        private float _currentMaxSpeed = 50;
        private float _currentMinSpeed = 20;
        private MovementDirection _direction;
        private float _distanceUntilNextCar;
        private IDrawManager _drawManager;
        private Car _lastCarAdded;
        private float _maxSpeed = 400;
        private Player _player;
        private IRandomizer _randomizer;
        private float _speed;

        private Func<IEnumerable<Car>> GetActiveCars;

        public Lane(DrawManager drawManager, Player player, IRandomizer randomizer, Rectangle boundingBox, MovementDirection direction)
        {
            this.Cars = new List<Car>();
            this.BoundingBox = boundingBox;

            _drawManager = drawManager;
            _direction = direction;
            _player = player;
            _randomizer = randomizer;
            _speed = _randomizer.NextFloat(_currentMinSpeed, _currentMaxSpeed);

            _carTexture = direction == MovementDirection.Right ?
                drawManager.LoadTexture("car", "car.png") :
                drawManager.LoadTexture("car", "car.png", TextureEffect.FlippedHorizontal);

            this.AddNewCar();

            // Helper functions
            GetActiveCars = new Func<IEnumerable<Car>>(() => this.Cars.Where(car => car.IsActive));
        }

        public Rectangle BoundingBox { get; private set; }

        public List<Car> Cars { get; private set; }

        public void IncreaseSpeed()
        {
            if (_currentMaxSpeed < _maxSpeed)
            {
                _currentMaxSpeed += 10;
            }

            if (_speed < _maxSpeed)
            {
                _speed += 10;
            }
        }

        public void Update(TimeSpan elapsedTime)
        {
            RemoveInactiveCars();
            CheckForPlayerCollision();
            SpawnNewCars(elapsedTime);
            UpdateCarMovements(elapsedTime);
        }

        internal void Draw()
        {
            foreach (var car in GetActiveCars())
            {
                _drawManager.Draw(car.Sprite);
            }
        }

        private void AddNewCar()
        {
            var startingPosition =
                _direction == MovementDirection.Right ?
                new Vector2(-_carTexture.Width, this.BoundingBox.Top) :
                new Vector2(this.BoundingBox.Right, this.BoundingBox.Top);
            this._lastCarAdded = new Car(startingPosition, _carTexture);
            this.Cars.Add(this._lastCarAdded);

            this._distanceUntilNextCar = _randomizer.NextFloat(46, 400);
        }

        private void CheckForPlayerCollision()
        {
            foreach (var car in this.Cars)
            {
                if (_player.BoundingBox.IntersectsWith(car.BoundingBox))
                {
                    _player.Hit();
                }
            }
        }

        private float GetDistanceFromLaneEntryPoint(Car car)
        {
            var distance = _direction == MovementDirection.Right ?
                car.BoundingBox.Left - this.BoundingBox.Left :
                this.BoundingBox.Right - car.BoundingBox.Right;
            return distance;
        }

        private bool HasCarLeftPlayingArea(Car car)
        {
            if (this._direction == MovementDirection.Right && car.BoundingBox.Left >= this.BoundingBox.Right)
            {
                return true;
            }
            else if (this._direction == MovementDirection.Left && car.BoundingBox.Right <= this.BoundingBox.Left)
            {
                return true;
            }

            return false;
        }

        private void RemoveInactiveCars()
        {
            var inactiveCars =
                this.Cars
                    .Where(car => !car.IsActive)
                    .ToArray()
                    .AsEnumerable();

            foreach (var car in inactiveCars)
            {
                this.Cars.Remove(car);
                car.Dispose();
            }
        }

        private void SpawnNewCars(TimeSpan elapsedTime)
        {
            if (this.GetDistanceFromLaneEntryPoint(this._lastCarAdded) > this._distanceUntilNextCar)
            {
                this.AddNewCar();
            }
        }

        private void UpdateCarMovements(TimeSpan elapsedTime)
        {
            // Loop through all the active cars
            foreach (var car in GetActiveCars())
            {
                // If a car is left the lane bounds, deactivate it
                if (HasCarLeftPlayingArea(car))
                {
                    car.Deactivate();
                    continue;
                }

                // Update the cars' movement
                var movement =
                    _direction == MovementDirection.Right ?
                    MovementVector.Right :
                    MovementVector.Left;
                movement *= (float)elapsedTime.TotalSeconds * _speed;
                car.SetMovement(movement);
            }
        }
    }
}