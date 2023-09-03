using System;
using System.Collections.Generic;
using engine.components;
using engine.interfaces;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace engine.systems;

public class SceneSystem : IDrawingSystem, IUpdateSystem, ILoadableSystem
{
    public void Draw(IEnumerable<IEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (!entity.HasComponent<SceneComponent>()) continue;
            if (!entity.GetComponent<SceneComponent>().Visible) continue;
            foreach (var sceneSystem in entity.GetComponent<SceneComponent>().Systems)
            {
                if (sceneSystem is IDrawingSystem drawingSystem)
                {
                    drawingSystem.Draw(entity.GetComponent<SceneComponent>().Entities);
                }
            }
        }
    }

    public void Update(IEnumerable<IEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (!entity.HasComponent<SceneComponent>()) continue;
            if (!entity.GetComponent<SceneComponent>().Visible) continue;
            foreach (var sceneSystem in entity.GetComponent<SceneComponent>().Systems)
            {
                if (sceneSystem is IUpdateSystem updateSystem)
                {
                    updateSystem.Update(entity.GetComponent<SceneComponent>().Entities);
                }
            }
        }
    }

    public void LoadContent(IEnumerable<IEntity> entities, ContentManager content, GraphicsDevice graphicsDevice)
    {
        foreach (var entity in entities)
        {
            if (!entity.HasComponent<SceneComponent>()) continue;
            if (!entity.GetComponent<SceneComponent>().Visible) continue;
            foreach (var sceneSystem in entity.GetComponent<SceneComponent>().Systems)
            {
                if (sceneSystem is ILoadableSystem loadableSystem)
                {
                    loadableSystem.LoadContent(entity.GetComponent<SceneComponent>().Entities, content, graphicsDevice);
                }
            }
        }
    }
}