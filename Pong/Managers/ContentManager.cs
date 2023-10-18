﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Menus;

namespace Pong.Managers;
public class ContentManager
{
    private Game1 Game;
    public SpriteBatch SpriteBatchGame { get; set; }
    public SpriteBatch SpriteBatchHUD { get; set; }


    public ContentManager(Game1 game)
    {
        Game = game;
        SpriteBatchGame = new SpriteBatch(Game.GraphicsDevice);
        SpriteBatchHUD = new SpriteBatch(Game.GraphicsDevice);
    }

    public void Draw()
    {
        DrawSpriteBatchGame();
        DrawSpriteBatchHUD();
    }

    private void DrawSpriteBatchHUD()
    {
        SpriteBatchHUD.Begin();
        DrawScore();
        DrawPauseMenu();
        SpriteBatchHUD.End();
    }

    private void DrawPauseMenu()
    {
        if (Game.Menu.Pause)
        {
            SpriteBatchHUD.DrawString(HUD.Font, HUD.PauseDisplayText, HUD.PausePosition, HUD.FontColor);

        }
    }

    private void DrawScore()
    {
        SpriteBatchHUD.DrawString(HUD.Font, HUD.ScoreDisplayText + ": " + HUD.Score.ToString(), HUD.ScorePosition, HUD.FontColor);
    }

    public void LoadContent()
    {
        Game.Player.Texture2D = Game.Content.Load<Texture2D>(Game.Player.Texture2DName);
        Game.Level.BackgroundTexture2D = Game.Content.Load<Texture2D>(Game.Level.BackgroundTexture2DName);
        HUD.Font = Game.Content.Load<SpriteFont>(HUD.FontName);
    }

    private void DrawSpriteBatchGame()
    {
        SpriteBatchGame.Begin();
        DrawBackground(SpriteBatchGame);
        DrawPlayer1(SpriteBatchGame);
        SpriteBatchGame.End();
    }

    private void DrawBackground(SpriteBatch spriteBatch)
    {
        SpriteBatchGame.Draw(Game.Level.BackgroundTexture2D, Game.ScreenRectangle,Color.White);
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

    public void Update(TimeSpan ElapsedTime)
    {
        HUD.Score = ElapsedTime.Seconds + ElapsedTime.Minutes * 60 + ElapsedTime.Hours * 360;
    }
}

