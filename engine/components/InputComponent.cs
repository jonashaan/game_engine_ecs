using engine.interfaces;
using Microsoft.Xna.Framework;

namespace engine.components;

public class InputComponent : IComponent
{
    public Vector2 Velocity { get; set; } = new(0, 0);
    public int Speed { get; set; } = 5;
}