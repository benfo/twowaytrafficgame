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
        private float _currentMaxSpeed = 100;
        private float _currentMinSpeed = 80;
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
                        
            // For the project, set all lanes to the same speed
            _speed = 100;

            // ...otherwise randomize speeds for each new lane. It makes the 
            // game a bit more interesting.
            // _speed = _randomizer.NextFloat(_currentMinSpeed, _currentMaxSpeed);

            // Based on the lane dirction, load a car texture facing right or left.
            _carTexture = direction == MovementDirection.Right ?
                drawManager.LoadTexture("car", "car.png") :
                drawManager.LoadTexture("car", "car.png", TextureEffect.FlippedHorizontal);

            // Immediately add a new car to the lane
            this.AddNewCar();

            // Define a helper function that selects all the active cars.
            GetActiveCars = new Func<IEnumerable<Car>>(() => this.Cars.Where(car => car.IsActive));
        }

        public Rectangle BoundingBox { get; private set; }

        public List<Car> Cars { get; private set; }

        public void IncreaseSpeed()
        {
            // Increase the lane speed. These hard coded values
            // should actually be configurable. Also make sure
            // the cars don't go faster than the maximum speed
            // because the game then becomes unplayable.

            if (_currentMaxSpeed < _maxSpeed)
            {
                _currentMaxSpeed += 10;
            }

            if (_speed < _maxSpeed)
            {
                _speed += 10;
            }
        }

        public void IncreaseTrafficFlow()
        {
            // TODO: Implement traffic flow increase
        }


        public void Update(TimeSpan elapsedTime)
        {
            // Updates various game states.
            
            RemoveInactiveCars();
            CheckForPlayerCollision();
            SpawnNewCars(elapsedTime);
            UpdateCarMovements(elapsedTime);
        }

        internal void Draw()
        {
            // Don't draw inactive cars because they 
            // have already moved off the screen
            foreach (var car in GetActiveCars())
            {
                _drawManager.Draw(car.Sprite);
            }
        }

        private void AddNewCar()
        {
            // Determine the starting position of the car. Either going from right>left
            // or from left>right on the screen.
            var startingPosition =
                _direction == MovementDirection.Right ?
                new Vector2(-_carTexture.Width, this.BoundingBox.Top) :
                new Vector2(this.BoundingBox.Right, this.BoundingBox.Top);
            this._lastCarAdded = new Car(startingPosition, _carTexture);
            this.Cars.Add(this._lastCarAdded);

            // Distance between the current car when the next one should
            // appear on the screen.
            this._distanceUntilNextCar = _randomizer.NextFloat(46, 400);
        }

        private void CheckForPlayerCollision()
        {
            // Check for car/player collision and make
            // the player "dead" when there is a hit.
            foreach (var car in this.Cars)
            {
                if (_player.BoundingBox.IntersectsWith(car.BoundingBox))
                {
                    _player.Hit();
                }
            }
        }

        private bool HasCarLeftPlayingArea(Car car)
        {
            // Check if the given car has left the lanes' playing area.
            // In this case it means the car dissapeared off the screen.
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
            // Remove inactive cars and make sure the resources
            // are cleaned up.
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
            // If the last car has moved far enough from the entry point
            // it's time to add another car to the lane.
            if (this.GetDistanceFromLaneEntryPoint(this._lastCarAdded) > this._distanceUntilNextCar)
            {
                this.AddNewCar();
            }
        }

        private float GetDistanceFromLaneEntryPoint(Car car)
        {
            // Gets the distance from where the given car has entered 
            // the current lane and where it is now.
            var distance = _direction == MovementDirection.Right ?
                car.BoundingBox.Left - this.BoundingBox.Left :
                this.BoundingBox.Right - car.BoundingBox.Right;
            return distance;
        }

        private void UpdateCarMovements(TimeSpan elapsedTime)
        {
            // Only update active/visible cars
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

        public void Unload()
        {
            // Unloads all car resources
            this.Cars.ForEach(car => car.Dispose());
        }
    }
}