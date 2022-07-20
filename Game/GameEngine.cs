using System.Diagnostics;
using Aludra.Game.Contexts;
using Aludra.Game.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game;

public class GameEngine : Microsoft.Xna.Framework.Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly InputHandler _inputHandler = new();
    private readonly SceneManager _sceneManager;
    private readonly ScreenScaler _screenScaler = new(800, 600);
    private readonly TextureCache _textureCache = new();
    private SpriteBatch? _spriteBatch;

    public GameEngine()
    {
        _graphics = new GraphicsDeviceManager(this);
        _sceneManager = new SceneManager(new Level());
        Content.RootDirectory = "Content";
        Window.AllowUserResizing = true;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
        _textureCache.LoadContent(Content);
    }

    protected override void Update(GameTime gameTime)
    {
        _inputHandler.Update();
        _screenScaler.Update(_graphics);
        _sceneManager.Update(new UpdateContext(gameTime, _inputHandler));
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        Debug.Assert(_spriteBatch != null);

        _graphics.GraphicsDevice.Clear(Color.Black);

        _spriteBatch.Begin(SpriteSortMode.Immediate, transformMatrix: _screenScaler.Transformation);
        _sceneManager.Draw(new DrawContext(_spriteBatch, _textureCache));
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
