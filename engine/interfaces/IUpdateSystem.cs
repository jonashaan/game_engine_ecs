using System.Collections.Generic;

namespace engine.interfaces;

public interface IUpdateSystem : ISystem
{
    public void Update(IEnumerable<IEntity> entities);
}