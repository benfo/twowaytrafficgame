using System;
using System.Collections.Generic;
using System.Linq;
using TWTGame.Core.Bootstrapper;
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
                var game = bootstrapper.GetGame();
                game.Run();
            }
        }
    }
}
