using Aroris_Platformer_Project.Src.Entities;
using Aroris_Platformer_Project.Src.LevelGen;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Collections;
using MonoGame.Extended.Screens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Aroris_Platformer_Project.Src.Screens
{
    public class MainScreen : GameScreen
    {
        private new Game1 Game => (Game1)base.Game;

        public MainScreen(Game1 game) : base(game) { }

        Player _Player;

        public List<Entity> entities = new List<Entity>(); //For running update and draw for everything, including stuff that isn't a platform or enemy

        //Lists for collision - IFL this isn't the most efficient way to do this
        public List<Block> platforms = new List<Block>();
        public List<Entity> enemies = new List<Entity>();

        LevelGen.LevelGenerator _levelGenerator;

        public override void Initialize()
        {
            _levelGenerator = new LevelGen.LevelGenerator(Content, entities, platforms, enemies);

            _levelGenerator.SpawnLevel(_levelGenerator.GenerateRandomLevel());

            _Player = new Player(Content, new Vector2(960, 540));
            entities.Add(_Player);

            //var Block = new Block(Content, new Vector2(1700, 900), Content.Load<Texture2D>("PrototypeArt/tile_brick"));
            //entities.Add(Block);

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

            //Debug.WriteLine(entities.Count); -- CONFIRMED THAT LEVELGEN IS ADDING TO THE ENTITIES LIST
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

        void CheckCollisions() //This does not currently take into account collision of player and enemy spawned items
        {
            //Check player collision with Ground
            foreach (Entity entity in platforms)
            {
                if (_Player.Collides(entity))
                {
                    //Player block collision logic
                    //  - Maybe just move the player to slightly in the opposite direction of its movement and set its velocity to zero
                }
            }

            foreach (Entity entity in enemies) //Will have to change this to use an Enemy type to implement damage later
            {
                if (_Player.Collides(entity))
                {
                    //Player enemy collision logic
                    //  - The player takes damage
                }
            }

            //Check player collision with enemies
        }
    }
}
