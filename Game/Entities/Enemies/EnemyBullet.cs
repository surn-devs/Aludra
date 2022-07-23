using Aludra.Game.Contexts;
using Aludra.Game.Entities.Base;
using Aludra.Game.Entities.Tags;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities.Enemies;

public class EnemyBullet : RigidBodyObject
{
    private const float Speed = 256;

    public EnemyBullet(Vector2 pos)
    {
        Position = pos;
        Velocity = Vector2.UnitY * Speed;
        Radius = 8;
    }

    public override void CollideWith(CollideContext context)
    {
        if (context.Other is not IDestroyableByEnemy) return;

        context.Destroy(this);
        context.Destroy(context.Other);
    }

    public override void Draw(DrawContext context) => context.DrawCentered("EnemyBullet", Position);
}
