using Aludra.Game.Contexts;
using Aludra.Game.Entities.Base;
using Aludra.Game.Entities.Tags;
using Aludra.Game.Timers;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities;

public class Player : RigidBodyObject, IDestroyableByEnemy
{
    private const float SlowSpeed = 96;
    private const float NormalSpeed = 192;
    private static readonly Vector2 SpawnPoint = new(400, 500);

    private readonly CooldownTimer _shootCooldown = new(0.5);

    public Player()
    {
        Position = SpawnPoint;
        Radius = 16;
    }

    public override void Update(LevelUpdateContext context)
    {
        var speedMultiplier = context.InputHandler.SecondActionPressed ? SlowSpeed : NormalSpeed;
        Velocity = context.InputHandler.DirectionVector * speedMultiplier;

        _shootCooldown.Update(context);
        if (context.InputHandler.PrimaryActionPressed && _shootCooldown.Act())
            context.Spawn(new PlayerBullet(Position));

        base.Update(context);
    }

    public override void Draw(DrawContext context) => context.DrawCentered("Player", Position);
}
