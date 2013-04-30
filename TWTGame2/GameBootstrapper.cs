using MicroGe;
using MicroGe.Bootstrapper;
using MicroGe.Graphics;
using MicroGe.Input;
using MicroGe.Services;

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
            container.Register<IGame, TwoWayTrafficGame>()
                .AsSingleton();
        }
    }
}