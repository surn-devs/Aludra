using Aludra.Game.Contexts;
using Aludra.Game.Entities.Base;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities;

public class PlayerBullet : RigidBodyObject
{
    private const float Speed = 512;

    public PlayerBullet(Vector2 pos)
    {
        Position = pos;
        Velocity = -Vector2.UnitY * Speed;
    }

    public override void Draw(DrawContext context)
    {
        var texture = context.TextureManager.Get("PlayerBullet");
        var pos = Position - texture.Bounds.Center.ToVector2();
        context.SpriteBatch.Draw(texture, pos, Color.White);
    }
}
