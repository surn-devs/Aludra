using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game.Entities;

public class Player : GameObject
{
    private const float Speed = 128;
    private Vector2 _pos = new(400, 500);
    private Vector2 _vel = Vector2.Zero;

    public override void Update(GameTime gameTime)
    {
        _vel = InputHandler.DirectionVector * Speed;
        _pos += _vel * (float)gameTime.ElapsedGameTime.TotalSeconds;
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        var pos = _pos - TextureManager.Player!.Bounds.Center.ToVector2();
        spriteBatch.Draw(TextureManager.Player, pos, Color.White);
    }
}
