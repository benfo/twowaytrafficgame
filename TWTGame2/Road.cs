using System;
using System.Collections.Generic;
using System.Drawing;
using TWTGame.Core;
using TWTGame.Core.Graphics;
using TWTGame.Core.Input;
using TWTGame.Core.Services;

namespace TWTGame
{
    public class Road
    {
        private IDrawManager _drawManager;
        private IKeyboard _keyboard;
        private int _laneCount;
        private int _laneHeight;
        private Rectangle _playArea;
        private Player _player;
        private IRandomizer _randomizer;

        public Road(IDrawManager drawManager, IKeyboard keyboard, Player player, IRandomizer randomizer)
        {
            _drawManager = drawManager;
            _keyboard = keyboard;
            _player = player;
            _laneHeight = 65;
            this.Lanes = new List<Lane>();
            _laneCount = 5;
            _randomizer = randomizer;

            _playArea = new System.Drawing.Rectangle(
                0, 0,
                drawManager.ScreenSize.Width,
                drawManager.ScreenSize.Height - 100);

            for (int i = 0; i < _laneCount; i++)
            {
                Lanes.Add(CreateLane(i));
            }
        }

        public void Draw()
        {
            Lanes.ForEach(lane =>
            {
                lane.Draw();
            });
        }

        public void Update(TimeSpan elapsedTime)
        {
            Lanes.ForEach(lane => lane.Update(elapsedTime));
        }

        private Lane CreateLane(int laneIndex)
        {
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

        public List<Lane> Lanes { get; private set; }
    }
}