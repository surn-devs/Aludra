using Aludra.Game.Contexts;

namespace Aludra.Game.Timers;

public class CooldownTimer
{
    private readonly double _cooldown;
    private double _remaining;

    public CooldownTimer(double cooldown) => _cooldown = cooldown;

    public void Update(UpdateContext context)
    {
        _remaining -= context.GameTime.ElapsedGameTime.TotalSeconds;
    }

    public bool Act()
    {
        if (_remaining > 0) return false;

        _remaining = _cooldown;
        return true;
    }
}
