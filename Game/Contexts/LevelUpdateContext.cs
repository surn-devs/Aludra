using Aludra.Game.Entities.Base;
using Aludra.Game.Services;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Contexts;

public delegate void ObjectActionDelegate(GameObject gameObject);

public readonly record struct LevelUpdateContext(
    GameTime GameTime,
    InputHandler InputHandler,
    ObjectActionDelegate Spawn,
    ObjectActionDelegate Destroy
);
