using Aludra.Game.Contexts;
using Aludra.Game.Timers;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities.Player;

public class PlayerEntity : GameObject
{
    private const float SlowSpeed = 96;
    private const float NormalSpeed = 192;
    private static readonly Vector2 SpawnPoint = new(400, 500);

    private readonly CooldownTimer _shootCooldown = new(0.5);

    public PlayerEntity()
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

    public override void CollideWith(CollideContext context)
    {
        if (context.Other is not IDamagesPlayer) return;

        context.Destroy(this);
        context.Destroy(context.Other);
    }

    public override void Draw(DrawContext context) => context.DrawCentered("Player", Position);
}
