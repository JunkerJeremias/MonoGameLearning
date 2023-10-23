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
    //rotation in degrees
    public ParticleSystem ParticleSystem { get; set; }

    public Player() : this(new Vector2(0,0) ) 
        {}

        public Player(Vector2 position) :base(position, "textureatlas/smileywalk")
        {
            Speed = 200f;
            //Texture2DName = "textures/shuttle";
            //BoundingCircle = new(Position, (float)Width / 2f);
        }

        public override void Draw(SpriteBatch SpriteBatch)
        {
            AnimatedSprite.Draw(SpriteBatch, this);

        }
}

