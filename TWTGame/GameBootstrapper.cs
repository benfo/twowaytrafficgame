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
            // Register core services
            container.Register<IDrawManager, DrawManager>()
                .AsSingleton();
            container.Register<IKeyboard, Keyboard>()
                .AsSingleton();

            // Register the randomizer service
            container.Register<IRandomizer, Randomizer>()
                .AsSingleton();

            // Register the game, so that it can be constructed
            // using the IoC container
            container.Register<IGame, TwoWayTrafficGame>()
                .AsSingleton();
        }
    }
}