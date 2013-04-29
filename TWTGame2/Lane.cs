using SdlDotNet.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TWTGame.Core;
using TWTGame.Core.Graphics;

namespace TWTGame
{
    public class Lane
    {
        private float _currentMaxSpeed = 20;
        private float _currentMinSpeed = 50;
        private float _maxSpeed = 400;
        private float _distanceUntilNextCar;
        private Car _lastCarAdded;
        private IDrawManager _drawManager;
        private Player _player;
        private MovementDirection _direction;
        private IRandomizer _randomizer;
        private Surface _carTexture;
        private float _speed;

        public Lane(IDrawManager drawManager, Player player, IRandomizer randomizer, Rectangle boundingBox, MovementDirection direction)
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
        }

        public Rectangle BoundingBox { get; private set; }

        public List<Car> Cars { get; private set; }

        public void Update(TimeSpan elapsedTime)
        {
            RemoveInactiveCars();
            CheckForPlayerCollision();
            SpawnNewCars(elapsedTime);
            UpdateCarMovements(elapsedTime);
        }

        private void UpdateCarMovements(TimeSpan elapsedTime)
        {
            this.Cars.ForEach(car =>
            {
                if (car.IsActive)
                {
                    var movement =
                        _direction == MovementDirection.Right ?
                        MovementVector.Right :
                        MovementVector.Left;
                    movement *= (float)elapsedTime.TotalSeconds * _speed;
                    car.SetMovement(movement);
                }
            });
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
            this.Cars.ForEach(car =>
            {
                if (_player.BoundingBox.IntersectsWith(car.BoundingBox))
                {
                    _player.Hit();
                }
            });
        }

        private float DistanceFromLaneEntryPoint(Car car)
        {
            var distance = _direction == MovementDirection.Right ?
                car.BoundingBox.Left - this.BoundingBox.Left :
                this.BoundingBox.Right - car.BoundingBox.Right;
            return distance;
        }

        private void RemoveInactiveCars()
        {
            var inactiveCars = this.Cars.Where(car => !car.IsActive).ToArray();
            foreach (var car in inactiveCars)
            {
                car.Unload();
                this.Cars.Remove(car);
            }
        }

        private void SpawnNewCars(TimeSpan elapsedTime)
        {
            if (this.DistanceFromLaneEntryPoint(this._lastCarAdded) > this._distanceUntilNextCar)
            {
                this.AddNewCar();
            }
        }


        public void IncreaseSpeed()
        {
            _speed += 10;
        }

        internal void Draw()
        {
            this.Cars.ForEach(car =>
            {
                if (car.IsActive)
                {
                    _drawManager.Draw(car);
                }
            });
        }

    }
}