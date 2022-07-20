using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Aludra.Game.Entities;

public abstract class GameObject
{
    public virtual void Update(GameTime gameTime)
    {
    }

    public virtual void Draw(SpriteBatch spriteBatch)
    {
    }
}
