using System.Collections.Generic;
using engine.components;
using engine.entities;
using engine.interfaces;
using engine.systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace engine;

// TODO: game / window config (fps, ...)

public class TestGame : Microsoft.Xna.Framework.Game
{
    private GraphicsDeviceManager _graphics;
    public List<IEntity> WorldEntities = new();
    public List<ISystem> WorldSystems = new();

    public TestGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        var testEntity = new TestEntity(
            new SpriteComponent()
            {
                TextureName = "sprites/ball",
                Position = new Vector2(100, 100),
                Visible = true
            },
            new InputComponent()
        );
        var testScene = new SceneEntity(name: "TestScene", visible: true);
        testScene.GetComponent<SceneComponent>().Entities.Add(testEntity);
        testScene.GetComponent<SceneComponent>().Systems.Add(new InputSystem());
        
        WorldEntities.Add(testScene);
        WorldSystems.Add(new SceneSystem());
        

        base.Initialize();
    }

    protected override void LoadContent()
    {
        foreach (var system in WorldSystems)
        {
            if (system is ILoadableSystem loadableSystem)
            {
                loadableSystem.LoadContent(WorldEntities, Content, GraphicsDevice);
            }
        }
       
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();
        
        foreach (var system in WorldSystems)
        {
            if (system is IUpdateSystem updateSystem)
            {
                updateSystem.Update(WorldEntities);
            }
        }
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        foreach (var system in WorldSystems)
        {
            if (system is IDrawingSystem drawingSystem)
            {
                drawingSystem.Draw(WorldEntities);
            }
        }


        base.Draw(gameTime);
    }
}