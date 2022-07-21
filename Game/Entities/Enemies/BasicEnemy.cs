using System;
using Aludra.Game.Contexts;
using Aludra.Game.Entities.Base;
using Aludra.Game.Util;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Entities.Enemies;

public class BasicEnemy : RigidBodyObject
{
    private readonly float _horizontalFrequency;
    private readonly float _horizontalMultipliers;
    private readonly float _horizontalOffset;
    private readonly float _verticalFrequency;
    private readonly float _verticalMultipliers;
    private readonly float _verticalOffset;

    public BasicEnemy()
    {
        _horizontalFrequency = Rand.Between(0.0005f, 0.002f);
        _verticalFrequency = Rand.Between(0.00005f, 0.0005f);

        _horizontalMultipliers = Rand.Between(0.25f, 1);
        _verticalMultipliers = Rand.Between(0.1f, 0.75f);

        _horizontalOffset = Rand.Between(0, (float)(2 * Math.PI));
        _verticalOffset = Rand.Between(0, (float)(2 * Math.PI));
    }

    public override void Update(LevelUpdateContext context)
    {
        var timeSec = context.GameTime.TotalGameTime.TotalMilliseconds;
        var horizontalOscillation = (float)Math.Sin(_horizontalFrequency * timeSec + _horizontalOffset);
        var verticalOscillation = (float)Math.Sin(_verticalFrequency * timeSec + _verticalOffset);

        Position = new Vector2(
            GameEngine.ScreenBounds.Center.X +
            horizontalOscillation * _horizontalMultipliers * 0.9f * GameEngine.ScreenBounds.Width / 2f,
            ((1 + verticalOscillation) / 2 * _verticalMultipliers + 0.1f) * GameEngine.ScreenBounds.Height
        );

        base.Update(context);
    }

    public override void Draw(DrawContext context)
    {
        context.DrawCentered("BasicEnemy", Position);
    }
}
