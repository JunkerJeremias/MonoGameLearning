using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.Entities.Particles
{
    internal class ParticleSystemBuilder
    {
        private static List<Texture2D> _textureSet;

        private static List<string> _textureNameSetStars = new()
        {
            "textures/particles/star",
            "textures/particles/circle",
            "textures/particles/diamond"
        };

        private ParticleSystemBuilder(){}

        public static ParticleSystem MakeParticleSetStars(ContentManager content, Vector2 location)
        {
            _textureSet = new();
            
            foreach(var name in _textureNameSetStars) 
            {
                _textureSet.Add(content.Load<Texture2D>(name));
            }
            
            return new ParticleSystem(_textureSet, location);
        }
    }
}
