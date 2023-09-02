using System;
using System.Collections.Generic;
using System.Linq;
using engine.components;
using engine.interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace engine.systems;

public class InputSystem : IUpdateSystem
{
    private readonly Dictionary<Keys, Action<IEntity>> _keyActions = new()
    {
        {Keys.W, entity => entity.GetComponent<InputComponent>().Velocity += new Vector2(0, -1)},
        {Keys.A, entity => entity.GetComponent<InputComponent>().Velocity += new Vector2(-1, 0)},
        {Keys.S, entity => entity.GetComponent<InputComponent>().Velocity += new Vector2(0, 1)},
        {Keys.D, entity => entity.GetComponent<InputComponent>().Velocity += new Vector2(1, 0)},
    };
    

    public void Update(IEnumerable<IEntity> entities)
    {
        foreach (var entity in entities)
        {
            if (!entity.HasComponent<InputComponent>()) continue;
            if (!entity.HasComponent<SpriteComponent>()) continue;
            
            if (Keyboard.GetState().GetPressedKeys().Any())
            {
                foreach (var key in Keyboard.GetState().GetPressedKeys())
                {
                    _keyActions.TryGetValue(key, out var action);
                    action?.Invoke(entity);
                }
            } else {
                entity.GetComponent<InputComponent>().Velocity = new Vector2(0, 0);
            }

            if (entity.GetComponent<InputComponent>().Velocity != Vector2.Zero)
            {
                entity.GetComponent<InputComponent>().Velocity =
                    Vector2.Normalize(entity.GetComponent<InputComponent>().Velocity);
            }
            entity.GetComponent<SpriteComponent>().Position +=
                entity.GetComponent<InputComponent>().Velocity *
                entity.GetComponent<InputComponent>().Speed;
        }
    }
}