using Aludra.Game.Contexts;

namespace Aludra.Game.Entities.Base;

public abstract class GameObject
{
    public virtual void Update(LevelUpdateContext context)
    {
    }

    public virtual void Draw(DrawContext context)
    {
    }
}
