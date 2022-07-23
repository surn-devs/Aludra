using Aludra.Game.Contexts;
using Aludra.Game.Entities.Base;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities.Enemies;

public class EnemyBullet : RigidBodyObject
{
    private const float Speed = 256;

    public EnemyBullet(Vector2 pos)
    {
        Position = pos;
        Velocity = Vector2.UnitY * Speed;
    }

    public override void Draw(DrawContext context) => context.DrawCentered("EnemyBullet", Position);
}
