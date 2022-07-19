using System;
using Aludra.Core;

namespace Aludra.DesktopGL
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using var game = new AludraGame();
            game.Run();
        }
    }
}
