using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
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
        //AdditiveBlending.Draw(SpriteBatchAdditiveBlending);
        Game.Player.ParticleSystem.Draw(SpriteBatchAdditiveBlending);
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
        Game.Player.BoundingCircle = new(Game.Player.Position + Game.Player.Origin, (float)Game.Player.Width / 2f);
        Game.Player.ParticleSystem = ParticleSystemBuilder.MakeParticleSetStars(Game.Content, Game.Player.Position);

        foreach (var entity in Game.Entities)
        {
            entity.Texture2D = Game.Content.Load<Texture2D>(entity.Texture2DName);
            entity.BoundingCircle = new(entity.Position + entity.Origin, (float)entity.Width / 2f);
        }
        Game.Level.BackgroundTexture2D = Game.Content.Load<Texture2D>(Game.Level.BackgroundTexture2DName);
        HUD.Font = Game.Content.Load<SpriteFont>(HUD.FontName);
    }

    private void DrawSpriteBatchGame()
    {
        SpriteBatchGame.Begin();
        DrawBackground(SpriteBatchGame);
        DrawEntities(SpriteBatchGame);
        SpriteBatchGame.End();
    }

    private void DrawBackground(SpriteBatch spriteBatch)
    {
        SpriteBatchGame.Draw(Game.Level.BackgroundTexture2D, Game.ScreenRectangle,Color.White);
    }

    private void DrawEntities(SpriteBatch SpriteBatch)
    {
        Game.Player.Draw(SpriteBatch);
        foreach (var entity in Game.Entities)
        {
            entity.Draw(SpriteBatch);
        }
    }

    public void Update(TimeSpan ElapsedTime)
    {
        HUD.Score = ElapsedTime.Seconds + ElapsedTime.Minutes * 60 + ElapsedTime.Hours * 360;
        AdditiveBlending.UpdateAngles();
        Game.Player.AnimatedSprite.Update();
        Game.Player.ParticleSystem.Update(Game.Player.Position, Game.Player.Rotation);
        HandleCollision(Game.Entities);
    }

    private void HandleCollision(List<Entity> gameEntities)
    {
        foreach (var entity in Game.Entities)
        {
            if (Game.Player.BoundingCircle.Colliding(entity.BoundingCircle))
                Game.Menu.Pause = true;
        }
    }
}

