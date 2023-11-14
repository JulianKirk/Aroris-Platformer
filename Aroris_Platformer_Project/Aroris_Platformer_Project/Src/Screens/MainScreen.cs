using Aroris_Platformer_Project.Src.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Collections;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aroris_Platformer_Project.Src.Screens
{
    public class MainScreen : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;

        public MainScreen(Game1 game) : base(game) { }

        Player _Player;

        public Deque<Entity> entities = new Deque<Entity>(); //For running update and draw for everything, including stuff that isn't a platform or enemy

        //Lists for collision - IFL this isn't the most efficient way to do this
        //public Deque<Entity> platforms = new Deque<Entity>();
        //public Deque<Entity> enemies = new Deque<Entity>();

        public override void Initialize()
        {
            _Player = new Player(Content);
            entities.AddToFront(_Player);

            var Block = new Block(Content, new Vector2(1700, 900));
            entities.AddToFront(Block);

            base.Initialize();
        }

        public override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(gameTime);
            }

            CheckCollisions();
        }

        public override void Draw(GameTime gameTime)
        {
            Game._spriteBatch.Begin();

            foreach (Entity entity in entities)
            {
                entity.Draw(gameTime, Game._spriteBatch);
            }

            Game._spriteBatch.End();
        }

        void CheckCollisions()
        {
            //Check player collision with Ground

            //Check player collision with enemies
        }
    }
}
