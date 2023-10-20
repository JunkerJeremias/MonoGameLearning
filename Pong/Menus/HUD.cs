using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Menus
{
    public static class HUD
    {
        public static SpriteFont Font { get; set; }
        public static string FontName { get; set; } = "SpriteFonts/HUDFont";
        public static string ScoreDisplayText { get; } = "Score";
        public static string PauseDisplayText { get; } = "Pause";
        public static Vector2 ScorePosition { get; set; } = new Vector2(10,10);
        public static Vector2 PausePosition { get; set; } = new Vector2(100, 100);
        public static Color FontColor { get; set; } = Color.White;
        public static int Score { get; set; } = 0;
    }
}
