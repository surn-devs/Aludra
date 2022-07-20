using Aludra.Game.Contexts;

namespace Aludra.Game.Scenes;

public abstract class Scene
{
    public abstract void Update(UpdateContext context);
    public abstract void Draw(DrawContext context);
}
