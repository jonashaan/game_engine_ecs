using System.Collections.Generic;
using engine.components;
using engine.entities;
using engine.interfaces;
using engine.systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace engine;

public class TestGame : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    public List<IEntity> Entities = new();
    public List<ISystem> Systems = new();

    public TestGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        Systems.Add(new InputSystem());
        Systems.Add(new SpriteSystem());
        
        Entities.Add(new TestEntity(
            new InputComponent(),
            new SpriteComponent()
            {
                TextureName = "sprites/ball"
            }
            )
        );
        
        base.Initialize();
    }

    protected override void LoadContent()
    {
        foreach (var system in Systems)
        {
            if (system is ILoadableSystem loadableSystem)
            {
                loadableSystem.LoadContent(Entities, Content, GraphicsDevice);
            }
        }
       
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        foreach (var system in Systems)
        {
            if (system is IUpdateSystem updateSystem)
            {
                updateSystem.Update(Entities);
            }
        }
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        foreach (var system in Systems)
        {
            if (system is IDrawingSystem drawingSystem)
            {
                drawingSystem.Draw(Entities);
            }
        }


        base.Draw(gameTime);
    }
}