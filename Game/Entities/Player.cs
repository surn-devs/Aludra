using Aludra.Game.Contexts;
using Aludra.Game.Entities.Base;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities;

public class Player : RigidBodyObject
{
    private const float SlowSpeedUps = 96;
    private const float NormalSpeedUps = 192;
    private const float ShootCooldownS = 0.5f;
    private static readonly Vector2 SpawnPoint = new(400, 500);

    private float _shootCooldown;

    public Player()
    {
        Position = SpawnPoint;
    }

    public override void Update(LevelUpdateContext context)
    {
        var speedMultiplier = context.InputHandler.SecondActionPressed ? SlowSpeedUps : NormalSpeedUps;
        Velocity = context.InputHandler.DirectionVector * speedMultiplier;

        _shootCooldown -= (float)context.GameTime.ElapsedGameTime.TotalSeconds;
        if (context.InputHandler.PrimaryActionPressed && _shootCooldown <= 0)
        {
            _shootCooldown = ShootCooldownS;
            context.Spawn(new PlayerBullet(Position));
        }

        base.Update(context);
    }

    public override void Draw(DrawContext context)
    {
        context.DrawCentered("Player", Position);
    }
}
