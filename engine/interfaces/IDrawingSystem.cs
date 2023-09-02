using System.Collections.Generic;

namespace engine.interfaces;

public interface IDrawingSystem : ISystem
{
    public void Draw(IEnumerable<IEntity> entities);
}