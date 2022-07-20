using Aludra.Game.Contexts;
using Aludra.Game.Entities;
using Microsoft.Xna.Framework;

namespace Aludra.Game.Scenes;

public class Level : Scene
{
    private readonly Player _player = new();

    public override void Update(UpdateContext context)
    {
        _player.Update(context);
    }

    public override void Draw(DrawContext context)
    {
        context.SpriteBatch.Draw(context.TextureCache.Background, Vector2.Zero, Color.White);

        _player.Draw(context);
    }
}
