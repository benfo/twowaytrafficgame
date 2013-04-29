using System;
using TinyIoC;

namespace TWTGame.Core.Bootstrapper
{
    public class DefaultBootstrapper : BootstrapperBase<TinyIoCContainer>, IDisposable
    {
        protected sealed override TinyIoCContainer GetContainer()
        {
            return new TinyIoCContainer();
        }

        protected override void ConfigureResolver(TinyIoCContainer container)
        {
            DependencyResolver.SetResolver(new DefaultDependencyResolver(container));
        }

        public override IGame GetGame()
        {
            return this.Container.Resolve<IGame>();
        }

        public void Dispose()
        {
            this.Container.Dispose();
        }
    }
}