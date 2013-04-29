using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWTGame.Bootstrapper
{
    public interface IDependencyResolver
    {
        T GetService<T>()
            where T : class;
        IEnumerable<T> GetServices<T>()
            where T : class;
    }
}
