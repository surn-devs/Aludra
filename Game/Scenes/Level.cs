using Aludra.Game.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game.Scenes;

public class Level : Scene
{
    private readonly Player _player = new();

    public override void Update(GameTime gameTime)
    {
        _player.Update(gameTime);
    }

    public override void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(TextureManager.Background, Vector2.Zero, Color.White);
        _player.Draw(spriteBatch);
    }
}
