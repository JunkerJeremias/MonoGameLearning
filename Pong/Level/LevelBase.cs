using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Level
{
    public class LevelBase
    {
        public Texture2D BackgroundTexture2D { get; set; }
        public string BackgroundTexture2DName { get; protected set; }
    }
}
