using System.Collections.Generic;
using engine.components;
using engine.interfaces;
using Microsoft.Xna.Framework;

namespace engine.entities;

public class SceneEntity : BaseEntity
{
    public SceneEntity(params IComponent[] components)
    {
        if (components is null) return;
        foreach (var component in components)
        {
            AddComponent(component);
        }
    }
    public SceneEntity(string name, bool visible)
    {
        AddComponent(new SceneComponent()
        {
            Name = name,
            Visible = visible,
        });
    }
    public SceneEntity(string name, bool visible, ICollection<IEntity> entities, ICollection<ISystem> systems)
    {
        AddComponent(new SceneComponent()
        {
            Name = name,
            Visible = visible,
            Entities = entities,
            Systems = systems,
        });
    }
    
}
