using Aludra.Game.Contexts;

namespace Aludra.Game.Entities;

public abstract class GameObject
{
    public virtual void Update(UpdateContext context)
    {
    }

    public virtual void Draw(DrawContext context)
    {
    }
}
