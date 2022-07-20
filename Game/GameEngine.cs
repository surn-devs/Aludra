using System.Diagnostics;
using Aludra.Game.Contexts;
using Aludra.Game.Scenes;
using Aludra.Game.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game;

public class GameEngine : Microsoft.Xna.Framework.Game
{
    private readonly GraphicsDeviceManager _graphics;
    private readonly InputHandler _inputHandler = new();
    private readonly SceneManager _sceneManager = new(new Level());
    private readonly ScreenScaler _screenScaler = new(800, 600);
    private readonly TextureManager _textureManager;
    private SpriteBatch? _spriteBatch;

    public GameEngine()
    {
        _graphics = new GraphicsDeviceManager(this);
        _textureManager = new TextureManager(Content);
        Content.RootDirectory = "Content";
        Window.AllowUserResizing = true;
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);
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
        _sceneManager.Draw(new DrawContext(_spriteBatch, _textureManager));
        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
