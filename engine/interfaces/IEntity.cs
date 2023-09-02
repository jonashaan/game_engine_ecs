using System;

using System.Collections.Generic;


namespace engine.interfaces;

public interface IEntity
{
    public Guid Id { get; }
    public Dictionary<Type, IComponent> Components { get; }
    public void AddComponent(IComponent component);
    public void RemoveComponent(IComponent component);
    public T GetComponent<T>() where T : class, IComponent;
    public bool HasComponent<T>() where T : class, IComponent;
}