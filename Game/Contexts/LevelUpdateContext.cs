using System;
using Aludra.Game.Entities.Base;
using Aludra.Game.Services;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Contexts;

public record LevelUpdateContext(
    GameTime GameTime,
    InputHandler InputHandler,
    Action<GameObject> Spawn,
    Action<GameObject> Destroy
);
