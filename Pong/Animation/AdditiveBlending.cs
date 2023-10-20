using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Animation
{
    public class AdditiveBlending
    {
        private Texture2D _textureBlue;
        private string _textureBlueName = "Textures/blue";
        private float _blueAngle = 0;
        private float _blueSpeed = 0.025f;
        private Texture2D _textureRed;
        private string _textureRedName = "Textures/red";
        private float _redAngle = 0;
        private float _redSpeed = 0.022f;
        private Texture2D _textureGreen;
        private string _textureGreenName = "Textures/green";
        private float _greenAngle = 0;
        private float _greenSpeed = 0.017f;

        private float _distance = 100;

        public AdditiveBlending(ContentManager Content)
        {
            _textureBlue = Content.Load<Texture2D>(_textureBlueName);
            _textureRed = Content.Load<Texture2D>(_textureRedName);
            _textureGreen = Content.Load<Texture2D>(_textureGreenName);
        }

        public void UpdateAngles()
        {
            _blueAngle += _blueSpeed;
            _greenAngle += _greenSpeed;
            _redAngle += _redSpeed;
        }

        public void Draw(SpriteBatch SpriteBatch)
        {
            Vector2 bluePosition = new Vector2(
                (float)Math.Cos(_blueAngle) * _distance,
                (float)Math.Sin(_blueAngle) * _distance);
            Vector2 greenPosition = new Vector2(
                (float)Math.Cos(_greenAngle) * _distance,
                (float)Math.Sin(_greenAngle) * _distance);
            Vector2 redPosition = new Vector2(
                (float)Math.Cos(_redAngle) * _distance,
                (float)Math.Sin(_redAngle) * _distance);

            Vector2 center = new Vector2(300, 140);

            SpriteBatch.Draw(_textureBlue, center + bluePosition, Color.White);
            SpriteBatch.Draw(_textureGreen, center + greenPosition, Color.White);
            SpriteBatch.Draw(_textureRed, center + redPosition, Color.White);
        }
    }
}
