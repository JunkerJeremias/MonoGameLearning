using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.Entities;
using Pong.Level;
using Pong.Managers;
using Pong.Menus;

namespace Pong;

public class Game1 : Game
{
    public Player Player { get; set; }
    public LevelBase Level { get; set; }
    public int? ScreenWidth => _graphics?.PreferredBackBufferWidth;
    public int? ScreenHeight => _graphics?.PreferredBackBufferHeight;
    public TimeSpan ElapsedTime { get; private set; }
    


    public Rectangle ScreenRectangle => new Rectangle(0, 0, ScreenWidth?? 0, ScreenHeight?? 0);
    public MainMenu Menu { get; }

    private ContentManager _content;
    private InputManager _inputManager;
    private GraphicsDeviceManager _graphics;


    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        Menu = new MainMenu(Window);
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        _content = new ContentManager(this);
        _inputManager = new InputManager(this);

        Player = new Player(new Vector2((float)(ScreenWidth / 2), (float)(ScreenHeight / 2)));
        Level = new Level1();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        _content.LoadContent();
    }

    protected override void Update(GameTime gameTime)
    {
        
        // TODO: Add your update logic here
        _inputManager.ParseInput(gameTime);

        if (!Menu.Pause)
        {
            UpdateGameTime(gameTime);

            _content.Update(ElapsedTime);
        }
        base.Update(gameTime);
        
    }

    private void UpdateGameTime(GameTime gameTime)
    {
        ElapsedTime += gameTime.ElapsedGameTime;
    }

    protected override void Draw(GameTime gameTime)
    {
        //GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here

        _content.Draw();
        base.Draw(gameTime);


    }
}
