using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game.Contexts;

public record DrawContext(SpriteBatch SpriteBatch, TextureCache TextureCache)
{
    public readonly SpriteBatch SpriteBatch = SpriteBatch;
    public readonly TextureCache TextureCache = TextureCache;
}
