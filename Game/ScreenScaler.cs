using Microsoft.Xna.Framework;

namespace Aludra.Game;

public class ScreenScaler
{
    private readonly Vector2 _baseScreenSize;
    private int _previousBufferHeight;
    private int _previousBufferWidth;

    public ScreenScaler(uint width, uint height)
    {
        _baseScreenSize = new Vector2(width, height);
    }

    public Matrix Transformation { get; private set; }

    public void Update(GraphicsDeviceManager graphics)
    {
        if (_previousBufferHeight == graphics.GraphicsDevice.PresentationParameters.BackBufferHeight &&
            _previousBufferWidth == graphics.GraphicsDevice.PresentationParameters.BackBufferWidth) return;

        _previousBufferWidth = graphics.GraphicsDevice.PresentationParameters.BackBufferWidth;
        _previousBufferHeight = graphics.GraphicsDevice.PresentationParameters.BackBufferHeight;

        var horizontalScaling = _previousBufferWidth / _baseScreenSize.X;
        var verticalScaling = _previousBufferHeight / _baseScreenSize.Y;
        var screenScaling = new Vector3(horizontalScaling, verticalScaling, 1);

        Transformation = Matrix.CreateScale(screenScaling);
    }
}
