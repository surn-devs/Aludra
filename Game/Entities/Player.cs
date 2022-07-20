using Aludra.Game.Contexts;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities;

public class Player : GameObject
{
    private const float Speed = 128;
    private Vector2 _pos = new(400, 500);
    private Vector2 _vel = Vector2.Zero;

    public override void Update(UpdateContext context)
    {
        _vel = context.InputHandler.DirectionVector * Speed;
        _pos += _vel * (float)context.GameTime.ElapsedGameTime.TotalSeconds;
    }

    public override void Draw(DrawContext context)
    {
        var texture = context.TextureManager.Get("Player");
        var pos = _pos - texture.Bounds.Center.ToVector2();
        context.SpriteBatch.Draw(texture, pos, Color.White);
    }
}
