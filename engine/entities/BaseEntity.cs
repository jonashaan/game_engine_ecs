using System;
using System.Collections.Generic;
using engine.interfaces;

namespace engine.entities;

public abstract class BaseEntity : IEntity
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public Dictionary<Type, IComponent> Components { get; private set; } = new();
    
    
    public void AddComponent(IComponent component)
    {
        Components[component.GetType()] = component;
    }

    public void RemoveComponent(IComponent component)
    {
        Components.Remove(component.GetType());
    }
    
    public T GetComponent<T>() where T : class, IComponent
    {
        Components.TryGetValue(typeof(T), out IComponent component);
        return component as T;
    }
    
    public bool HasComponent<T>() where T : class, IComponent
    {
        return Components.ContainsKey(typeof(T));
    }
    
}