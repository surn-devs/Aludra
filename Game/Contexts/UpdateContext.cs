using Aludra.Game.Services;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Contexts;

public record UpdateContext(GameTime GameTime, InputHandler InputHandler)
{
    public readonly GameTime GameTime = GameTime;
    public readonly InputHandler InputHandler = InputHandler;
}
