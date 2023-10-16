using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Entities;
public abstract class Entity
{
    public Vector2 Position { get; set; }
    public float Speed { get; set; }
    public Texture2D Texture2D { get; set; }
    public Vector2 Origin { get; }
    
    public int? Height => Texture2D?.Height;
    public int? Width => Texture2D?.Width;

    public string Texture2DName { get; set; }
    public Color Color { get; set; }

}

