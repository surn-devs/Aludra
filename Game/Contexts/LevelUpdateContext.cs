using Aludra.Game.Entities;
using Aludra.Game.Services;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Contexts;

public delegate void ObjectActionDelegate(GameObject gameObject);

public readonly record struct LevelUpdateContext(GameTime GameTime, InputHandler InputHandler,
    ObjectActionDelegate Spawn, ObjectActionDelegate Destroy)
{
    public readonly ObjectActionDelegate Destroy = Destroy;
    public readonly GameTime GameTime = GameTime;
    public readonly InputHandler InputHandler = InputHandler;
    public readonly ObjectActionDelegate Spawn = Spawn;
}
