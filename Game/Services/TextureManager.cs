using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game.Services;

public class TextureManager
{
    private readonly ContentManager _contentManager;
    private readonly Dictionary<string, Texture2D> _textureCache = new();

    public TextureManager(ContentManager contentManager)
    {
        _contentManager = contentManager;
    }

    public Texture2D Get(string name)
    {
        if (!_textureCache.ContainsKey(name))
            _textureCache[name] = _contentManager.Load<Texture2D>($"Textures/{name}");

        return _textureCache[name];
    }
}
