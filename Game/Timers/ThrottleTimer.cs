using Aludra.Game.Contexts;

namespace Aludra.Game.Timers;

public class ThrottleTimer
{
    private readonly double _interval;
    private double _remaining;

    public ThrottleTimer(double interval, bool startsImmediately = true)
    {
        _interval = interval;
        _remaining = startsImmediately ? 0 : interval;
    }

    public bool UpdateAndAct(UpdateContext context)
    {
        _remaining -= context.GameTime.ElapsedGameTime.TotalSeconds;

        if (_remaining > 0) return false;

        _remaining = _interval;
        return true;
    }
}
