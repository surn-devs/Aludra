using System;
using Aludra.Game;

namespace Aludra;

public static class Program
{
    [STAThread]
    private static void Main()
    {
        using var game = new GameEngine();
        game.Run();
    }
}
