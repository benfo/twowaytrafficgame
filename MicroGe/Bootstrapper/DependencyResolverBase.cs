using System.Collections.Generic;

namespace MicroGe.Bootstrapper
{
    /// <summary>
    /// Base class that configures a dependency container and provides
    /// access to the dependency resolver instance.
    /// </summary>
    /// <typeparam name="TContainer">The type of the container.</typeparam>
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