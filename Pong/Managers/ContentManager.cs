using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Animation;
using Pong.Entities;
using Pong.Entities.Particles;
using Pong.Menus;

namespace Pong.Managers;
public class ContentManager
{
    private Game1 Game;
    public SpriteBatch SpriteBatchGame { get; set; }
    public SpriteBatch SpriteBatchHUD { get; set; }
    public SpriteBatch SpriteBatchAdditiveBlending { get; set; }

    public AdditiveBlending AdditiveBlending { get; set; }

    public ContentManager(Game1 game)
    {
        Game = game;
        SpriteBatchGame = new SpriteBatch(Game.GraphicsDevice);
        SpriteBatchHUD = new SpriteBatch(Game.GraphicsDevice);
        SpriteBatchAdditiveBlending = new SpriteBatch(Game.GraphicsDevice);

        AdditiveBlending = new(Game.Content);
    }

    public void Draw()
    {
        DrawSpriteBatchGame();
        DrawAdditiveSpriteBatch();
        DrawSpriteBatchHUD();
    }

    private void DrawAdditiveSpriteBatch()
    {
        SpriteBatchAdditiveBlending.Begin(SpriteSortMode.Immediate,BlendState.Additive );
        AdditiveBlending.Draw(SpriteBatchAdditiveBlending);
        SpriteBatchAdditiveBlending.End();

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
        Game.Player.AnimatedSprite = new AnimatedSprite(Game.Player.Texture2D, 4, 4);
        Game.Player.ParticleSystem = ParticleSystemBuilder.MakeParticleSetStars(Game.Content, Game.Player.Position);
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
        Game.Player.AnimatedSprite.Draw(SpriteBatch,Game.Player.Position, Game.Player.Origin);
        Game.Player.ParticleSystem.Draw(SpriteBatch);   
    }

    public void Update(TimeSpan ElapsedTime)
    {
        HUD.Score = ElapsedTime.Seconds + ElapsedTime.Minutes * 60 + ElapsedTime.Hours * 360;
        AdditiveBlending.UpdateAngles();
        Game.Player.AnimatedSprite.Update();
        Game.Player.ParticleSystem.Update(Game.Player.Position, Game.Player.Rotation);
    }
}

