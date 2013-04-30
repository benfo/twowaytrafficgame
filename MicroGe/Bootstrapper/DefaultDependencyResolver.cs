using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TinyIoC;

namespace MicroGe.Bootstrapper
{
    public class DefaultDependencyResolver : DependencyResolverBase<TinyIoCContainer>
    {
        public DefaultDependencyResolver(TinyIoCContainer container)
            : base(container)
        {
        }

        public override T GetService<T>()
        {
            return this.Container.Resolve<T>();
        }

        public override IEnumerable<T> GetServices<T>()
        {
            return this.Container.ResolveAll<T>();
        }
    }
}
