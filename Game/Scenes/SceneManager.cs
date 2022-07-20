using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game.Scenes;

public class SceneManager
{
    private readonly Scene _currentScene;

    public SceneManager(Scene initialScene)
    {
        _currentScene = initialScene;
    }

    public void Update(GameTime gameTime)
    {
        _currentScene.Update(gameTime);
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        _currentScene.Draw(spriteBatch);
    }
}
