using Aludra.Game.Contexts;
using Aludra.Game.Entities.Player;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities.Enemies;

public class EnemyBullet : GameObject, IDamagesPlayer
{
    private const float Speed = 256;

    public EnemyBullet(Vector2 pos)
    {
        Position = pos;
        Velocity = Vector2.UnitY * Speed;
        Radius = 8;
    }

    public override void Draw(DrawContext context) => context.DrawCentered("EnemyBullet", Position);
}
