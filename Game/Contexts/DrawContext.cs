using Aludra.Game.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game.Contexts;

public readonly record struct DrawContext(SpriteBatch SpriteBatch, TextureManager TextureManager)
{
    public void DrawCentered(string textureName, Vector2 centerPosition)
    {
        var texture = TextureManager.Get(textureName);
        var pos = centerPosition - texture.Bounds.Center.ToVector2();
        SpriteBatch.Draw(texture, pos, Color.White);
    }
}
