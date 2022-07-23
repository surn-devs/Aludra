using System;
using Aludra.Game.Contexts;
using Aludra.Game.Entities.Base;
using Aludra.Game.Timers;
using Aludra.Game.Util;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities.Enemies;

public class BasicEnemy : RigidBodyObject
{
    private static readonly Rectangle SafeArea;

    private readonly Vector2 _frequencies;
    private readonly Vector2 _multipliers;
    private readonly Vector2 _offsets;
    private readonly ThrottleTimer _shootTimer = new(1, false);

    static BasicEnemy()
    {
        var safeArea = new Rectangle(
            Point.Zero,
            new Point(GameEngine.ScreenBounds.Width, GameEngine.ScreenBounds.Height * 2 / 3)
        );
        safeArea.Inflate(-32, -32);
        SafeArea = safeArea;
    }

    public BasicEnemy()
    {
        _frequencies = new Vector2(
            Rand.Between(0.5f, 2),
            Rand.Between(0.05f, 0.5f)
        );

        _multipliers = new Vector2(
            Rand.Between(0.25f, 1),
            Rand.Between(0.1f, 1)
        );

        const float twoPi = (float)(2 * Math.PI);
        _offsets = new Vector2(
            Rand.Between(0, twoPi),
            Rand.Between(0, twoPi)
        );
    }

    public override void Update(LevelUpdateContext context)
    {
        var timeSeconds = context.GameTime.TotalGameTime.TotalSeconds;
        var oscillation = new Vector2(
            (float)Math.Sin(_frequencies.X * timeSeconds + _offsets.X) / 2f,
            (float)Math.Sin(_frequencies.Y * timeSeconds + _offsets.Y) / 2f
        );

        Position = new Vector2(
            SafeArea.Center.X + oscillation.X * SafeArea.Width * _multipliers.X,
            SafeArea.Center.Y + oscillation.Y * SafeArea.Height * _multipliers.Y
        );

        if (_shootTimer.UpdateAndAct(context)) context.Spawn(new EnemyBullet(Position));

        base.Update(context);
    }

    public override void Draw(DrawContext context) => context.DrawCentered("BasicEnemy", Position);
}