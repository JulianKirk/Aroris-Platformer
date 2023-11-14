using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Aroris_Platformer_Project.Src
{
    public class Player : Entity
    {
        private float _walkSpeed = 300f;

        public Player(ContentManager Content) : base(Content)
        {
            _height = 64;
            _width = 64;
            _position = new Vector2(960 - (_height/2), 540 - (_width/2));

            _velocity = new Vector2(0, 100f);
        }

        protected override void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("PrototypeArt/character_roundPurple");
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().GetPressedKeyCount() > 0)
            {
                Vector2 movementVector = new Vector2(0, 0);

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    _velocity.X = _walkSpeed;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    _velocity.X = -_walkSpeed;
                }
            } 
            else
            {
                _velocity.X = 0f; //This implementation can easily be super sus in the future - overrides any other horizontal velocity changes
            }
        }
    }
}
