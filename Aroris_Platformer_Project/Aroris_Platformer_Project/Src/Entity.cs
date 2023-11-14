using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using MonoGame.Extended.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aroris_Platformer_Project.Src
{
    public class Entity
    {
        public float _height;
        public float _width;

        public Vector2 _position; //Top left of the object
        public Vector2 _velocity;
        //public Vector2 _Acceleration;

        // Could use Monogame.Extended Scenegraph setup instead with Transform2
        // Would allow for easy rotation logic

        public Texture2D _texture;

        public Entity(ContentManager Content)
        {            
            LoadContent(Content);
            //Initializing can just be done in the inherited constructor
        }

        protected virtual void LoadContent(ContentManager Content)
        {

        }

        public virtual void Update(GameTime gameTime) 
        {
            _position += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public virtual void Draw(GameTime gameTime, SpriteBatch _spriteBatch) //Probably won't need to be overriden for most early cases
        {
            _spriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
