using System;
using Aludra.Game;

namespace Aludra
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            using var game = new GameEngine();
            game.Run();
        }
    }
}

namespace System.Runtime.CompilerServices
{
    // ReSharper disable once UnusedType.Global
    internal static class IsExternalInit
    {
    }
}
