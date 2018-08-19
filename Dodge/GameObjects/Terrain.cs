
using Dodge.GameObjects;
using System;

namespace Dodge
{
    public class Terrain
    {
        public const int TERRAINSTATE_FIRE = 1;
        public const int TERRAINSTATE_ENEMY1 = 2;
        public const int TERRAINSTATE_ENEMY2 = 3;
        public const int TERRAINSTATE_NONE = 4;

        public int PosX { get; set; }
        public int PosY { get; set; }
        public int TerrainType { get; set; }

        public Terrain(int PosX, int PosY, int TerrainType)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.TerrainType = TerrainType;
            
        }
    }
}
