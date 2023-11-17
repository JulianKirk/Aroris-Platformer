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

namespace Aroris_Platformer_Project.Src.Entities
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

        public bool Collides(Entity otherEntity) //AABB collision
        {
            return _position.X < otherEntity._position.X + otherEntity._width &&
                    _position.X + _width > otherEntity._position.X &&
                    _position.Y < otherEntity._position.Y + otherEntity._height &&
                    _position.Y + _height > otherEntity._position.Y;
        }

        public int CollideWithSolids(List<Block> solids) //0 - no collision 1 - top, 2 - right, 3 - down, 4 - left
        {
            float verticalDiff = 0f;
            float horizontalDiff = 0f;

            float totalDiff = 0;

            Block selectedSolid = null;

            foreach (Block solid in solids) //Linear search for the closest collision solid
            {
                if (Collides(solid))
                {
                    float tempVerticalDiff = solid._position.Y - _position.Y; //Positive = other entity is below
                    float tempHorizontalDiff = solid._position.X - _position.X;//Positive = other entity is to the right

                    double tempTotalDiff = Math.Sqrt((double)((tempHorizontalDiff*tempHorizontalDiff) + (tempVerticalDiff*tempVerticalDiff)));
                    if (tempTotalDiff > totalDiff)
                    {
                        totalDiff = (float)tempTotalDiff;
                        verticalDiff = tempVerticalDiff;
                        horizontalDiff = tempHorizontalDiff;

                        selectedSolid = solid;
                    }
                }
            }

            if (totalDiff > 0 && selectedSolid != null)
            {
                if (verticalDiff > 0)
                {
                    if (Math.Abs(verticalDiff) > Math.Abs(horizontalDiff)) //Top Collision
                    {
                        _position.Y -= (_height / 2 + selectedSolid._height / 2) - Math.Abs(verticalDiff);
                        return 1;
                    }
                    else
                    {
                        if (horizontalDiff > 0) //Right Collision
                        {
                            _position.X -= (_width / 2 + selectedSolid._width / 2) - Math.Abs(horizontalDiff);
                            return 2;
                        }
                        else //Left Collision
                        {
                            _position.X += (_width / 2 + selectedSolid._width / 2) - Math.Abs(horizontalDiff);
                            return 4;
                        }
                    }
                }
                else
                {
                    if (Math.Abs(verticalDiff) > Math.Abs(horizontalDiff)) //Bottom Collision
                    {
                        _position.Y += (_height / 2 + selectedSolid._height / 2) - Math.Abs(verticalDiff);
                        return 3;
                    }
                    else
                    {
                        if (horizontalDiff > 0) //Right Collision
                        {
                            _position.X -= (_width / 2 + selectedSolid._width / 2) - Math.Abs(horizontalDiff);
                            return 2;
                        }
                        else //Left Collision
                        {
                            _position.X += (_width / 2 + selectedSolid._width / 2) - Math.Abs(horizontalDiff);
                            return 4;
                        }
                    }
                }
            }
            
            return 0;
        }
    }
}
