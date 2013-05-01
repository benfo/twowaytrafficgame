using MicroGe.Graphics;
using MicroGe.Services;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace TWTGame
{
    public class Road
    {
        private DrawManager _drawManager;
        private int _initialLaneCount;
        private int _laneHeight;
        private Rectangle _playArea;
        private Player _player;
        private IRandomizer _randomizer;
        private int _maxLaneCount;

        public Road(Player player, DrawManager drawManager, IRandomizer randomizer)
        {
            _drawManager = drawManager;
            _player = player;
            _laneHeight = 65;
            _initialLaneCount = 2;
            _maxLaneCount = 8;
            _randomizer = randomizer;

            // Set the playing area equal to the screen width and 100 
            // pixels less on the height. This gives the player a nice 
            // starting position.
            _playArea = new System.Drawing.Rectangle(
                0, 0,
                drawManager.ScreenSize.Width,
                drawManager.ScreenSize.Height - 100);

            this.Lanes = new List<Lane>();
            for (int i = 0; i < _initialLaneCount; i++)
            {
                Lanes.Add(CreateLane(i));
            }
        }

        public List<Lane> Lanes { get; private set; }

        public void Draw()
        {
            // Draw game objects
            Lanes.ForEach(lane => lane.Draw());
        }

        public void IncreaseLanes(int count)
        {
            var currentLaneCount = this.Lanes.Count;

            // Cannot add more lanes that the max specified
            if (currentLaneCount >= _maxLaneCount)
            {
                return;
            }

            for (int i = 0; i < count; i++)
            {
                // Add new lanes until it reaches the max number 
                // of lanes that may be added.
                var newLaneCount = i + currentLaneCount;
                if (newLaneCount < _maxLaneCount)
                {
                    this.Lanes.Add(CreateLane(newLaneCount));
                }
            }
        }

        public void Update(TimeSpan elapsedTime)
        {
            // Update game objects
            Lanes.ForEach(lane => lane.Update(elapsedTime));
        }

        private Lane CreateLane(int laneIndex)
        {
            // Creates a new lane. Even numbered lanes will move left, and odd numbered lanes will move right.

            var laneStartY = _playArea.Height - (laneIndex * _laneHeight);

            var laneBounds =
                new Rectangle(
                    0,
                    laneStartY,
                     _playArea.Width,
                    _laneHeight);

            var laneDirection = laneIndex % 2 == 0 ? MovementDirection.Left : MovementDirection.Right;
            var lane = new Lane(
                    _drawManager,
                    _player,
                    _randomizer,
                    laneBounds,
                    laneDirection);

            return lane;
        }

        public void Unload()
        {
            // Unloads all lane resources
            Lanes.ForEach(lane => lane.Unload());
        }
    }
}