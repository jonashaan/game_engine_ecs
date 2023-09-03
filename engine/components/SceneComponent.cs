using System.Collections.Generic;
using engine.interfaces;
using engine.systems;
using Microsoft.Xna.Framework;

namespace engine.components;

public class SceneComponent : IComponent
{
    public string Name { get; set; } = "Scene";
    public bool Visible { get; set; } = true;
    public ICollection<IEntity> Entities { get; set; } = new List<IEntity>();
    public ICollection<ISystem> Systems { get; set; } = new List<ISystem>(){new SpriteSystem()};
}