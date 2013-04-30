using MicroGe;
using System;
namespace MicroGe.Bootstrapper
{
    public abstract class BootstrapperBase<TContainer> : IBootstrapper
        where TContainer : class
    {
        protected TContainer Container { get; private set; }

        public void Initialize()
        {
            this.Container = this.GetContainer();

            this.ConfigureResolver(this.Container);

            this.ConfigureContainer(this.Container);
        }

        protected abstract void ConfigureResolver(TContainer container);

        protected virtual void ConfigureContainer(TContainer container)
        {
        }

        protected abstract TContainer GetContainer();

        public abstract IGame GetGame();
    }
}