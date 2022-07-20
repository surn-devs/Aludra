using Aludra.Game.Contexts;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities;

public class PlayerBullet : GameObject
{
    private const float SpeedUps = 512;
    private Vector2 _pos;

    public PlayerBullet(Vector2 pos)
    {
        _pos = pos;
    }

    public override void Update(LevelUpdateContext context)
    {
        _pos -= Vector2.UnitY * SpeedUps * (float)context.GameTime.ElapsedGameTime.TotalSeconds;

        if (_pos.Y < 0) context.Destroy(this);
    }

    public override void Draw(DrawContext context)
    {
        var texture = context.TextureManager.Get("PlayerBullet");
        var pos = _pos - texture.Bounds.Center.ToVector2();
        context.SpriteBatch.Draw(texture, pos, Color.White);
    }
}
