using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game;

public class GameEngine : Microsoft.Xna.Framework.Game
{
    private readonly Vector2 _baseScreenSize = new(800, 480);
    private readonly GraphicsDeviceManager _graphics;
    private int _backbufferHeight;
    private int _backbufferWidth;
    private Texture2D? _background;
    private Matrix _globalTransformation;
    private SpriteBatch? _spriteBatch;

    public GameEngine()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
    }

    private void ScalePresentationArea()
    {
        _backbufferWidth = GraphicsDevice.PresentationParameters.BackBufferWidth;
        _backbufferHeight = GraphicsDevice.PresentationParameters.BackBufferHeight;
        var horScaling = _backbufferWidth / _baseScreenSize.X;
        var verScaling = _backbufferHeight / _baseScreenSize.Y;
        var screenScalingFactor = new Vector3(horScaling, verScaling, 1);
        _globalTransformation = Matrix.CreateScale(screenScalingFactor);
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(_graphics.GraphicsDevice);

        _background = Content.Load<Texture2D>("image/background");
    }

    protected override void Update(GameTime gameTime)
    {
        if (_backbufferHeight != GraphicsDevice.PresentationParameters.BackBufferHeight ||
            _backbufferWidth != GraphicsDevice.PresentationParameters.BackBufferWidth)
            ScalePresentationArea();

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        Debug.Assert(_spriteBatch != null);

        _graphics.GraphicsDevice.Clear(Color.Red);
        _spriteBatch.Begin(SpriteSortMode.Immediate, null, null, null, null, null, _globalTransformation);

        _spriteBatch.Draw(_background, Vector2.Zero, Color.White);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
