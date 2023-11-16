using Aroris_Platformer_Project.Src.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Aroris_Platformer_Project.Src.LevelGen
{
    public class LevelManager
    {
        ContentManager Content;

        List<Entity> _entities;
        List<Block> _platforms;
        List<Entity> _enemies;

        public LevelManager(ContentManager content, List<Entity> entities, List<Block> platforms, List<Entity> enemies) 
        {
            Content = content;

            _entities = entities;
            _platforms = platforms;
            _enemies = enemies;
        }

        public Level GenerateRandomLevel()
        {
            Level newLevel = new Level(new Vector2(0, 0), 64, 30, 16);

            for (int i = 0; i  < 30; i++)
            {
                newLevel.tileMap[i, 15] = Content.Load<Texture2D>("PrototypeArt/tile_brick");
            }

            return newLevel;
        }

        public void StoreRandomLevel(Level level)
        {
            
        }

        public Level RetrieveLevel()
        {
            Level retrievedLevel = null;

            //Use Newtonsoft to retrieve a level object

            return retrievedLevel;
        }

        public void SpawnLevel(Level levelToSpawn)
        {
            int tileSize = levelToSpawn._tileSize;
            int width = levelToSpawn._width;
            int height = levelToSpawn._height;
            Vector2 topLeftPosition = levelToSpawn._position;

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (levelToSpawn.tileMap[x, y] != null)
                    {
                        Entities.Block newBlock = new Entities.Block(Content,
                            new Vector2(topLeftPosition.X + (x * tileSize), topLeftPosition.Y + (y * tileSize)),
                            Content.Load<Texture2D>("PrototypeArt/tile_brick"));//levelToSpawn.tileMap[x, y]);

                        _entities.Add(newBlock);
                        _platforms.Add(newBlock);
                    }

                    if (levelToSpawn.enemyMap[x, y] != null)
                    {
                        //Spawn enemy and add to list
                    }
                }
            }
        }
    }
}
