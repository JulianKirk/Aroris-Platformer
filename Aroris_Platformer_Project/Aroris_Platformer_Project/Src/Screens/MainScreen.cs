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

        public Deque<Entity> entities = new Deque<Entity>();

        public override void Initialize()
        {
            entities.AddToFront(new Player(Content));
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
    }
}
