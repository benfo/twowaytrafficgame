using System;
using TinyIoC;

namespace TWTGame.Bootstrapper
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

        public void Dispose()
        {
            this.Container.Dispose();
        }
    }
}