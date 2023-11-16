using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aroris_Platformer_Project.Src.LevelGen
{
    public class Level
    //Expand this to include enemy and object pickup stuff
    {
        public Vector2 _position; //Top left of the level
        public int _width;
        public int _height;
        public int _tileSize;

        //Height is lowest at the top and smallest at the bottom
        public Entities.Entity[,] enemyMap;
        public Entities.Entity[,] objectMap;
        public Texture2D[,] tileMap;

        public Level(Vector2 position, int tileSize, int width, int height) //Width and height referring to the amount of 64 by 64 tiles
        {
            _position = position;
            _width = width;
            _height = height;
            _tileSize = tileSize;

            tileMap = new Texture2D[width, height];
            objectMap = new Entities.Entity[width, height];
            enemyMap = new Entities.Entity[width, height];
        }
    }
}
