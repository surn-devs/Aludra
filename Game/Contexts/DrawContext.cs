using Aludra.Game.Services;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game.Contexts;

public record DrawContext(SpriteBatch SpriteBatch, TextureManager TextureManager)
{
    public readonly SpriteBatch SpriteBatch = SpriteBatch;
    public readonly TextureManager TextureManager = TextureManager;
}
