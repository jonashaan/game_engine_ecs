using System.Collections.Generic;
using engine.components;
using engine.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace engine.systems;

public class SpriteSystem : ILoadableSystem, IDrawingSystem
{
    private SpriteBatch SpriteBatch { get; set; }
    
    public void LoadContent(IEnumerable<IEntity> entities, ContentManager content, GraphicsDevice graphicsDevice)
    {
        foreach (var entity in entities)
        {
            if (!entity.HasComponent<SpriteComponent>()) continue;
            var component = entity.GetComponent<SpriteComponent>();
            component.Texture = content.Load<Texture2D>(component.TextureName);
        }
        SpriteBatch = new SpriteBatch(graphicsDevice);
    }
    
    public void Draw(IEnumerable<IEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (!entity.HasComponent<SpriteComponent>()) continue;
            var component = entity.GetComponent<SpriteComponent>();
            SpriteBatch.Begin();
            if (component.Visible)
                SpriteBatch.Draw(texture: component.Texture, position: component.Position, color: Color.White);
            SpriteBatch.End();
        }
    }
}