using engine.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace engine.components;

public class SpriteComponent : IComponent
{
    public Vector2 Position { get; set; } = new(0, 0);
    public Texture2D Texture { get; set; } = null!;
    public string TextureName { get; set; } = "sprites/missing";
}