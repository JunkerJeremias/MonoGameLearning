using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Menus;
public class MainMenu
{
    private bool _pause;
    public bool Pause
    {
        get => _pause;
        set
        {
            _pause = value;
            if (_pause == true)
            {
                _window.Title = "Game Paused";
                return;
            }

            _window.Title = "Pong";

        }
    }
    private readonly GameWindow _window;

    public MainMenu(GameWindow window)
    {
        _window = window;
    }
}

