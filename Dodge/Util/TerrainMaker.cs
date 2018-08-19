using System;
using System.Collections.Generic;

namespace Dodge.Util
{
    /// <summary>
    /// Name:       Jo Lim
    /// Date:         Aug 8 2018
    /// Purpose:    This class randomly generates terrains
    /// </summary>

    static class TerrainMaker
    {
        public static List<Terrain> Generate(int row, int column, int screenWidth, int screenHeight)
        {
            int celWidth = (int)(screenWidth / row);
            int celHeight = (int) (screenHeight / row);
            List<Terrain> _terrains = new List<Terrain>();

            Random r = new Random();

            for (int i = 0; i < row; i++) {
                for (int j = 0; j < column; j++) {
                    _terrains.Add(new Terrain(i*celWidth, j*celHeight, r.Next(4)));
                }
            }

            return _terrains;
        }
    }
}
