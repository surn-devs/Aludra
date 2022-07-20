using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game;

public class TextureCache
{
    public Texture2D? Background { get; private set; }
    public Texture2D? Player { get; private set; }

    public void LoadContent(ContentManager content)
    {
        Background = content.Load<Texture2D>("image/background");
        Player = content.Load<Texture2D>("image/player");
    }
}
