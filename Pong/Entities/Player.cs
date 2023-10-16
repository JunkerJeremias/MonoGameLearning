using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Entities;

public class Player : Entity
{
    public new Vector2 Origin
    {
        get { return new Vector2((float)(Width / 2), (float)(Height / 2)); }
    }

    public Player() : this(new Vector2(0,0) ) 
        {}

        public Player(Vector2 position)
        {
            Position = position;
            Speed = 100f;
            Color = Color.AliceBlue;
            Texture2DName = "textures/ball";
        }
    }

