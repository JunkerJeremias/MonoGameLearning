using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Pong.Entities;

namespace Pong.Animation
{
    public class AnimatedSprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int _currentFrame;
        private int _totalFrames;

        public AnimatedSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            _currentFrame = 0;
            _totalFrames = Rows * Columns;
        }
        public void Update()
        {
            _currentFrame++;
            if (_currentFrame == _totalFrames)
                _currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Player player)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = _currentFrame / Columns;
            int column = _currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)player.Position.X, (int)player.Position.Y, width, height);
            
            //spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.Draw(Texture, player.Position, sourceRectangle,
                Color.White,
                (float)Math.PI * player.Rotation / 180.0f,
                player.Origin,
                Vector2.One,
                SpriteEffects.None,
                0f
            );
        }
    }
}
