using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Animation;

namespace Pong.Entities
{
    public class AnimatedEntity : Entity
    {
        public AnimatedSprite AnimatedSprite { get; set; }

        public new int? Height => Texture2D?.Height / AnimatedSprite?.Columns?? 1;
        public new int? Width => Texture2D?.Width / AnimatedSprite?.Rows?? 1;

        public new Vector2 Origin
        {
            get { return new Vector2((float)(Width / 2), (float)(Height / 2)); }
        }

        public AnimatedEntity(Vector2 position, string textureName) : base(position, textureName)
        {

        }
    }
}
