using Aludra.Game.Contexts;
using Aludra.Game.Entities.Base;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities;

public class Player : RigidBodyObject
{
    private const float SlowSpeed = 96;
    private const float NormalSpeed = 192;
    private const double ShootCooldown = 0.5f;
    private static readonly Vector2 SpawnPoint = new(400, 500);

    private double _shootCooldown;

    public Player()
    {
        Position = SpawnPoint;
    }

    public override void Update(LevelUpdateContext context)
    {
        var speedMultiplier = context.InputHandler.SecondActionPressed ? SlowSpeed : NormalSpeed;
        Velocity = context.InputHandler.DirectionVector * speedMultiplier;

        _shootCooldown -= context.GameTime.ElapsedGameTime.TotalSeconds;
        if (context.InputHandler.PrimaryActionPressed && _shootCooldown <= 0)
        {
            _shootCooldown = ShootCooldown;
            context.Spawn(new PlayerBullet(Position));
        }

        base.Update(context);
    }

    public override void Draw(DrawContext context)
    {
        context.DrawCentered("Player", Position);
    }
}
