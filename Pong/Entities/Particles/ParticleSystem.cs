using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Pong.Entities.Particles
{
    public class ParticleSystem
    {
        private Random _random;
        public Vector2 EmitterLocation { get; set; }
        private List<Particle> _particles;
        private List<Texture2D> _textures;

        public ParticleSystem(List<Texture2D> textures, Vector2 location)
        {
            EmitterLocation = location;
            _textures = textures;
            _particles = new List<Particle>();
            _random = new Random();
        }

        private Particle GenerateNewParticle(float speed = 4.0f, float spinningSpeed = 0.1f, int ttl = 20, int rotation = 359)
        {
            Texture2D texture = _textures[_random.Next(_textures.Count)];
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(
                    speed * (float)(_random.NextDouble() * 2),
                    speed * (float)(_random.NextDouble() * 2)
            );
            rotation = ((rotation - 45) % 360);
            double angle = Math.PI * rotation / 180.0;
            float cos = (float)Math.Cos(angle);
            float sin = (float)Math.Sin(angle);
            //rotate by x degrees
            velocity = new(cos * velocity.X - sin * velocity.Y,
                sin * velocity.X + cos * velocity.Y
            );
            float angularVelocity = spinningSpeed * (float)(_random.NextDouble() * 2 - 1);
            Color color = new Color(
                (float)_random.NextDouble(),
                (float)_random.NextDouble(),
                (float)_random.NextDouble());
            float size = (float)_random.NextDouble();
            ttl += _random.Next(40);

            return new Particle(texture, position, velocity, 0, angularVelocity, color, size, ttl);
        }
        public void Update(Vector2 location, int rotation = 1, int total = 10)
        {
            
            EmitterLocation = location;
            for (int i = 0; i < total; i++)
            {
                _particles.Add(GenerateNewParticle(rotation: rotation));
            }
            _particles.ForEach(particle => particle.Update());
            _particles.RemoveAll(particle => particle.TTL == 0);

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var particle in _particles)
            {
                particle.Draw(spriteBatch);
            }
        }
    }
}
