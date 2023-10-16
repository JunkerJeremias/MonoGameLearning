using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Managers;
public class ContentManager
{
    private Game1 Game;
    public SpriteBatch SpriteBatch { get; set; }


    public ContentManager(Game1 game)
    {
        Game = game;
        SpriteBatch = new SpriteBatch(Game.GraphicsDevice);
    }

    public void Draw()
    {
        DrawSpriteBatch(SpriteBatch);
    }

    public void LoadContent()
    {
        var Player = Game.Player;
        Game.Player.Texture2D = Game.Content.Load<Texture2D>(Game.Player.Texture2DName);
       Game.Level.BackgroundTexture2D = Game.Content.Load<Texture2D>(Game.Level.BackgroundTexture2DName);
    }

    private void DrawSpriteBatch(SpriteBatch SpriteBatch)
    {
        SpriteBatch.Begin();
        DrawBackground(SpriteBatch);
        DrawPlayer1(SpriteBatch);
        SpriteBatch.End();
    }

    private void DrawBackground(SpriteBatch spriteBatch)
    {
        SpriteBatch.Draw(Game.Level.BackgroundTexture2D, Game.ScreenRectangle,Color.White);
    }

    private void DrawPlayer1(SpriteBatch SpriteBatch)
    {
        SpriteBatch.Draw(Game.Player.Texture2D, Game.Player.Position, null,
            Game.Player.Color,
            0f,
            Game.Player.Origin,
            Vector2.One,
            SpriteEffects.None,
            0f
        );
    }
}

