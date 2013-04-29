using System.Collections.Generic;

namespace TWTGame.Bootstrapper
{
    public abstract class DependencyResolverBase<TContainer> : IDependencyResolver
    {
        public DependencyResolverBase(TContainer container)
        {
            this.Container = container;
        }

        protected TContainer Container { get; private set; }

        public abstract T GetService<T>() where T : class;

        public abstract IEnumerable<T> GetServices<T>() where T : class;
    }
}