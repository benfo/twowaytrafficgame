using System;
using System.Collections.Generic;
using System.Linq;

namespace TWTGame
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            // Create and initialize the game bootstrapper,
            // and start the game!
            using (var bootstrapper = new GameBootstrapper())
            {
                bootstrapper.Initialize();
                var game = bootstrapper.GetGame();
                game.Run();
            }
        }
    }
}
