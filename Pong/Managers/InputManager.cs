using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Pong.Managers;
internal class InputManager
{
    private readonly Game1 _game;
    private bool _pausePressed;
    private bool _escapeHit;

    public bool PausePressed
    {
        get => _pausePressed;
        private set
        {
            _pausePressed = value;
            _game.Menu.Pause = _pausePressed;
        }
    }

    public InputManager(Game1 game)
    {
        _game = game;
    }

    public void ParseInput(GameTime gameTime)
    {
        HandleEscapeInput();

        if (PausePressed)
            return;

        HandlePlayerInput(gameTime);
    }

    private void HandlePlayerInput(GameTime gameTime)
    {

        var kstate = Keyboard.GetState();
        var player = _game.Player;
        var elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;


        if (kstate.IsKeyDown(Keys.Up))
        {
            player.Position = new Vector2(player.Position.X, player.Position.Y - player.Speed * elapsedTime);
            player.Speed += 1;
        }

        if (kstate.IsKeyDown(Keys.Down))
        {
            player.Position = new Vector2(player.Position.X, player.Position.Y + player.Speed * elapsedTime);
            player.Speed += 1;
        }

        if (kstate.IsKeyDown(Keys.Left))
        {
            player.Position = new Vector2(player.Position.X - player.Speed * elapsedTime, player.Position.Y);
            player.Speed += 1;
        }

        if (kstate.IsKeyDown(Keys.Right))
        {
            player.Position = new Vector2(player.Position.X + player.Speed * elapsedTime, player.Position.Y);
            player.Speed += 1;
        }

        if (kstate.IsKeyDown(Keys.Space))
        {
            player.Speed = 100;
        }

        if (player.Position.X > _game.ScreenWidth - player.Width / 2)
        {
            player.Position = new Vector2((float)(_game.ScreenWidth - player.Width / 2)
                , player.Position.Y);
        }
        else if (player.Position.X < player.Width / 2)
        {
            player.Position = new Vector2((float)(player.Width / 2)
                , player.Position.Y);
        }

        if (player.Position.Y > _game.ScreenHeight - player.Height / 2)
        {
            player.Position = new Vector2(player.Position.X, (float)(_game.ScreenHeight - player.Height / 2));
        }
        else if (player.Position.Y < player.Height / 2)
        {
            player.Position = new Vector2(player.Position.X, (float)(player.Height / 2));
        }
    }

    private void HandleEscapeInput()
    {
        var escHit = Keyboard.GetState().IsKeyDown(Keys.Escape);

        if (escHit && !_escapeHit)
        {
            PausePressed = !PausePressed;
            _escapeHit = true;
        }

        if (!escHit)
            _escapeHit = false;
    }
}

