using MicroGe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MicroGe.Bootstrapper
{
    public interface IBootstrapper
    {
        void Initialize();
        
        IGame GetGame();
    }
}
