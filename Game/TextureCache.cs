using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game;

public static class TextureManager
{
    public static Texture2D? Background { get; private set; }
    public static Texture2D? Player { get; private set; }

    public static void LoadContent(ContentManager content)
    {
        Background = content.Load<Texture2D>("image/background");
        Player = content.Load<Texture2D>("image/player");
    }
}
