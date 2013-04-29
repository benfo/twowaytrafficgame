using System;
using System.Collections.Generic;
using System.Linq;
using TWTGame.Bootstrapper;
using TWTGame.Core;
namespace TWTGame
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var bootstrapper = new GameBootstrapper())
            {
                bootstrapper.Initialize();
                var game = DependencyResolver.Current.GetService<Game>();
                game.Run();
            }
        }
    }
}
