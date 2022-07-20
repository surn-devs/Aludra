using Aludra.Game.Contexts;

namespace Aludra.Game.Scenes;

public class SceneManager
{
    private readonly Scene _currentScene;

    public SceneManager(Scene initialScene)
    {
        _currentScene = initialScene;
    }

    public void Update(UpdateContext context)
    {
        _currentScene.Update(context);
    }

    public void Draw(DrawContext context)
    {
        _currentScene.Draw(context);
    }
}
