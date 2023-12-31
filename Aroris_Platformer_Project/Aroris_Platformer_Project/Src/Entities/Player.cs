﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Aroris_Platformer_Project.Src.Entities
{
    public class Player : Entity
    {
        private float _walkSpeed = 500f;

        public bool isOnTheGround;

        float tempJumpCooldown = 0.1f;
        float tempJumpRemainingCooldown;

        public Player(ContentManager Content, Vector2 position) : base(Content)
        {
            _height = 64;
            _width = 63;
            _position = new Vector2(position.X - _width, position.Y - _height / 2); //Centres it on that spawn position, not consistent with block tho - maybe change

            _velocity = new Vector2(0, 0f);

            isOnTheGround = false; //False initially - WATCH THIS for possible bugs
            tempJumpRemainingCooldown = 0f;
        }

        protected override void LoadContent(ContentManager Content)
        {
            _texture = Content.Load<Texture2D>("PrototypeArt/character_roundPurple");
        }

        public override void Update(GameTime gameTime)
        {
            tempJumpRemainingCooldown -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!isOnTheGround)
            {
                _velocity.Y += CONSTANTS.kGravity * (float)gameTime.ElapsedGameTime.TotalSeconds;

                //_velocity.Y = 1910f ;
            }

            if (Keyboard.GetState().GetPressedKeyCount() > 0)
            {
                Vector2 movementVector = new Vector2(0, 0);

                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    movementVector.X += _walkSpeed;
                }

                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    movementVector.X += -_walkSpeed;
                }

                _velocity.X = movementVector.X;

                if (Keyboard.GetState().IsKeyDown(Keys.Space) && isOnTheGround == true && tempJumpRemainingCooldown < 0)
                {
                    Jump();

                    tempJumpRemainingCooldown = tempJumpCooldown;
                }
            }
            else
            {
                _velocity.X = 0f; //This implementation can easily be super sus in the future - overrides any other horizontal velocity changes
            }

            base.Update(gameTime);
        }

        public void CollideWithPlatform(List<Block> solids)
        {
            int direction = CollideWithSolids(solids); 

            switch(direction)
            {
                case 0: //No collision
                    isOnTheGround = false;
                    return;
                case 1: //Up
                    _velocity.Y = _velocity.Y > 0 ? 0f : _velocity.Y; //Only stop it if it is going down
                    isOnTheGround = true;
                    break;
                case 2: //Right
                    _velocity.X = _velocity.X < 0 ? 0f : _velocity.X;
                    break;
                case 3: //Down
                     _velocity.Y = _velocity.Y < 0 ? 0f : _velocity.Y; //Only stop it if it is going up
                    break;
                case 4: //Left
                    _velocity.X = _velocity.X > 0 ? 0f : _velocity.X;
                    break;
            }
        }

        void Jump()
        {
            _velocity.Y = -1000f;
        }
    }
}