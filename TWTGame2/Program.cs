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
            using (var gameManager = new GameManager())
            {
                gameManager.Run();
            }
        }
    }
}
