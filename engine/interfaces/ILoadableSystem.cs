using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace engine.interfaces;

public interface ILoadableSystem : ISystem
{
    public void LoadContent(IEnumerable<IEntity> entities, ContentManager content, GraphicsDevice graphicsDevice);
}