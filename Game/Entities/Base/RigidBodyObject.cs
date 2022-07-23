using Aludra.Game.Contexts;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities.Base;

public abstract class RigidBodyObject : GameObject
{
    public Vector2 Position { get; protected set; }
    protected Vector2 Velocity { get; set; }
    public float Radius { get; protected set; }

    public override void Update(LevelUpdateContext context)
    {
        var dt = (float)context.GameTime.ElapsedGameTime.TotalSeconds;
        var bounds = GameEngine.ScreenBounds;

        Position += Velocity * dt;

        if (!bounds.Contains(Position)) context.Destroy(this);

        base.Update(context);
    }

    public virtual void CollideWith(CollideContext context)
    {
    }
}
