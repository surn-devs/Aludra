using Aludra.Game.Contexts;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities.Base;

public abstract class RigidBodyObject : GameObject
{
    protected Vector2 Position { get; set; }
    protected Vector2 Velocity { get; set; }

    public override void Update(LevelUpdateContext context)
    {
        var dt = (float)context.GameTime.ElapsedGameTime.TotalSeconds;
        var bounds = GameEngine.ScreenBounds;

        Position += Velocity * dt;

        if (!bounds.Contains(Position)) context.Destroy(this);

        base.Update(context);
    }
}
