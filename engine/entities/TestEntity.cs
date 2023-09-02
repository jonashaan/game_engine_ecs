using engine.interfaces;


namespace engine.entities;

public class TestEntity : BaseEntity
{
    public TestEntity(params IComponent[] components)
    {
        if (components is null) return;
        foreach (var component in components)
        {
            AddComponent(component);
        }
    }
}