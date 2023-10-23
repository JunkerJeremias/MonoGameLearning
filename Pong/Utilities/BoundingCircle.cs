using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Utilities
{
    public class BoundingCircle
    {
        public Vector2 Position { get; set; }
        public float Radius { get; set; }

        public BoundingCircle(Vector2 position, float radius)
        {
            Position = position;
            Radius = radius;
        }

        public bool Colliding(BoundingCircle other)
        {
            float distance = (float)Math.Sqrt(Math.Pow(this.Position.X - other.Position.X, 2) +
                                              Math.Pow(this.Position.Y - other.Position.Y, 2));
            return distance < this.Radius + other.Radius;
        }
    }
}
