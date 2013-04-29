using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TWTGame.Core.Bootstrapper
{
    public interface IBootstrapper
    {
        void Initialize();
        
        IGame GetGame();
    }
}
