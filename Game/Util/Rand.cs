using System;

namespace Aludra.Game.Util;

public static class Rand
{
    private static readonly Random Random = new();

    public static float Between(float a, float b) => a + (float)Random.NextDouble() * (b - a);
}
