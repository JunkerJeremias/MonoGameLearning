using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Entities.Particles;

namespace Pong.Entities;

public class Player : AnimatedEntity
{
    public new Vector2 Origin
    {
        get { return new Vector2((float)(Width / 2), (float)(Height / 2)); }
    }

    //rotation in degrees
    public int Rotation { get; set; }
    public ParticleSystem ParticleSystem { get; set; }

    public Player() : this(new Vector2(0,0) ) 
        {}

        public Player(Vector2 position)
        {
            Position = position;
            Speed = 200f;
            Color = Color.White;
            Texture2DName = "textureatlas/smileywalk";
            Rotation = 0;
            //Texture2DName = "textures/shuttle";
        }
}

