using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWTGame.Bootstrapper
{
    public class DependencyResolver
    {
        public static IDependencyResolver Current { get; private set; }

        public static void SetResolver(IDependencyResolver resolver)
        {
            Current = resolver;
        }
    }
}
