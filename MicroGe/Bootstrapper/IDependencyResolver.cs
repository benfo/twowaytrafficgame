using System.Collections.Generic;

namespace MicroGe.Bootstrapper
{
    /// <summary>
    /// Provides methods for requesting game services.
    /// </summary>
    public interface IDependencyResolver
    {
        T GetService<T>()
            where T : class;

        IEnumerable<T> GetServices<T>()
            where T : class;
    }
}