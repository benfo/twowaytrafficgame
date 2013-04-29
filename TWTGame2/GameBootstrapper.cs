using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TWTGame.Core.Bootstrapper;
using TWTGame.Core;
using TWTGame.Core.Graphics;
using TWTGame.Core.Input;

namespace TWTGame
{
    public class GameBootstrapper : DefaultBootstrapper
    {
        protected override void ConfigureContainer(TinyIoC.TinyIoCContainer container)
        {
            // Core
            container.Register<IDrawManager, DrawManager>()
                .AsSingleton();
            container.Register<IKeyboard, Keyboard>()
                .AsSingleton();

            // Services
            container.Register<IRandomizer, Randomizer>()
                .AsSingleton();

            // Game
            container.Register<Game, TwoWayTrafficGame>()
                .AsSingleton();
        }

        public Game GetGame()
        {
            return this.Container.Resolve<Game>();
        }
    }
}
