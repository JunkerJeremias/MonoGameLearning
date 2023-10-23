using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Utilities;

namespace Pong.Entities;
public class Entity
{
    private Vector2 _position;
    public Vector2 Position
    {
        get => _position;
        set
        {
            _position = value;
            if (BoundingCircle != null)
            {
                BoundingCircle.Position  = value;
            }
        }

    }
    public int Rotation { get; set; }

    public float Speed { get; set; }
    public Texture2D Texture2D { get; set; }
    public Vector2 Origin
    {
        get { return new Vector2((float)(Width / 2), (float)(Height / 2)); }
    }
    public int? Height => Texture2D?.Height;
    public int? Width => Texture2D?.Width;

    public string Texture2DName { get; set; }
    public Color Color { get; set; }

    public BoundingCircle BoundingCircle { get; set; }

    public Entity(Vector2 position, string textureName)
    {
        Position = position;
        Speed = 100f;
        Color = Color.White;
        Texture2DName = textureName;
        Rotation = 0;
    }

    public virtual void Draw(SpriteBatch SpriteBatch)
    {
        int width = Texture2D.Width;
        int height = Texture2D.Height;
        
        Rectangle destinationRectangle = new Rectangle((int)Position.X, (int)Position.Y, width, height);

        SpriteBatch.Draw(Texture2D, destinationRectangle, Color.White);


    }
}

