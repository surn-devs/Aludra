using Aludra.Game.Services;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Contexts;

public readonly record struct UpdateContext(GameTime GameTime, InputHandler InputHandler);
