using Aludra.Game.Contexts;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities;

public class Player : GameObject
{
    private const float SlowSpeedUps = 96;
    private const float NormalSpeedUps = 192;
    private const float ShootCooldownS = 0.5f;

    private Vector2 _pos = new(400, 500);
    private float _shootCooldown;
    private Vector2 _vel = Vector2.Zero;

    public override void Update(LevelUpdateContext context)
    {
        var dt = (float)context.GameTime.ElapsedGameTime.TotalSeconds;

        var speedMultiplier = context.InputHandler.SecondActionPressed ? SlowSpeedUps : NormalSpeedUps;
        _vel = context.InputHandler.DirectionVector * speedMultiplier;
        _pos += _vel * dt;


        _shootCooldown -= dt;
        if (context.InputHandler.PrimaryActionPressed && _shootCooldown <= 0)
        {
            _shootCooldown = ShootCooldownS;
            context.Spawn(new PlayerBullet(_pos));
        }
    }

    public override void Draw(DrawContext context)
    {
        var texture = context.TextureManager.Get("Player");
        var pos = _pos - texture.Bounds.Center.ToVector2();
        context.SpriteBatch.Draw(texture, pos, Color.White);
    }
}
