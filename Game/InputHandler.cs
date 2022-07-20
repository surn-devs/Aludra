using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aludra.Game;

public static class InputHandler
{
    private static KeyboardState _keyboardState;

    private static readonly ImmutableDictionary<Keys, Vector2> Directions = new Dictionary<Keys, Vector2>
    {
        { Keys.W, new Vector2(0, -1) },
        { Keys.S, new Vector2(0, 1) },
        { Keys.A, new Vector2(-1, 0) },
        { Keys.D, new Vector2(1, 0) }
    }.ToImmutableDictionary();

    public static Vector2 DirectionVector
    {
        get
        {
            var direction = Vector2.Zero;

            foreach (var (key, vector) in Directions)
                if (_keyboardState.IsKeyDown(key))
                    direction += vector;

            if (direction.LengthSquared() > 0)
                direction.Normalize();

            return direction;
        }
    }

    public static void Update()
    {
        _keyboardState = Keyboard.GetState();
    }
}