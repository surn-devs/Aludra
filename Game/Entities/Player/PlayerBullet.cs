using Aludra.Game.Contexts;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities.Player;

public class PlayerBullet : GameObject
{
    private const float Speed = 512;

    public PlayerBullet(Vector2 pos)
    {
        Position = pos;
        Velocity = -Vector2.UnitY * Speed;
        Radius = 8;
    }

    public override void CollideWith(CollideContext context)
    {
        if (context.Other is not IDamageableByPlayer) return;

        context.Destroy(this);
        context.Destroy(context.Other);
    }

    public override void Draw(DrawContext context) => context.DrawCentered("PlayerBullet", Position);
}