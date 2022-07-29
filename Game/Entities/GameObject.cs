using Aludra.Game.Contexts;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities;

public abstract class GameObject
{
    public Vector2 Position { get; protected set; }
    protected Vector2 Velocity { get; set; }
    public float Radius { get; protected init; }

    public virtual void Update(LevelUpdateContext context)
    {
        var dt = (float)context.GameTime.ElapsedGameTime.TotalSeconds;
        var bounds = GameEngine.ScreenBounds;

        Position += Velocity * dt;

        if (!bounds.Contains(Position)) context.Destroy(this);
    }

    public virtual void Draw(DrawContext context)
    {
    }

    public virtual void CollideWith(CollideContext context)
    {
    }
}
