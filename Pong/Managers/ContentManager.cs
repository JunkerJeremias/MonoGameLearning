using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
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
        SpriteBatch.Begin();
        SpriteBatch.Draw(Game.Player.Texture2D, Game.Player.Position, null,
            Game.Player.Color,
            0f,
            Game.Player.Origin,
            Vector2.One,
            SpriteEffects.None,
            0f
        );
        SpriteBatch.End();
    }

    public void LoadContent()
    {
        var Player = Game.Player;
        Player.Texture2D = Game.Content.Load<Texture2D>(Player.Texture2DName);
    }

}

