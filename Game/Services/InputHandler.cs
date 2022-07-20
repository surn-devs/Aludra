using System.Collections.Generic;
using System.Collections.Immutable;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Aludra.Game.Services;

public class InputHandler
{
    private static readonly ImmutableDictionary<Keys, Vector2> Directions = new Dictionary<Keys, Vector2>
    {
        { Keys.W, -Vector2.UnitY },
        { Keys.S, Vector2.UnitY },
        { Keys.A, -Vector2.UnitX },
        { Keys.D, Vector2.UnitX }
    }.ToImmutableDictionary();

    private KeyboardState _keyboardState;

    public Vector2 DirectionVector
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

    public bool PrimaryActionPressed => _keyboardState.IsKeyDown(Keys.Space);

    public bool SecondActionPressed => _keyboardState.IsKeyDown(Keys.LeftShift);

    public void Update()
    {
        _keyboardState = Keyboard.GetState();
    }
}
