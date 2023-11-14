using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aroris_Platformer_Project.Src.Entities
{
    public class Block : Entity
    {
        public Block(ContentManager Content, Vector2 position) : base(Content)
        {
            _width = 64f;
            _height = 64f;

            _position = position;
        }

        protected override void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("PrototypeArt/tile_brick");
        }

        public override void Update(GameTime gameTime) 
        {
            //Overriding this as empty without running base.Update so it is a little faster
        }

        //Basically will just act as a sprite with collision logic
    }
}
