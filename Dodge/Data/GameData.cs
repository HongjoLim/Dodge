using Dodge.GameObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dodge.Data
{
    /// <summary>
    ///     Name: JO LIM
    ///     Date: Aug 19, 2018
    ///     Purpose: This class is to store game data into a text file
    ///                   Because flattening Game class causes problem,
    ///                   using this class, the system saves only essential data about the game
    /// </summary>
    class GameData
    {
        public GameData(){}

        public User User { get; set;}
        public Player Player { get; set; }
        public int Score { get; set; }
        public int Level { get; set; }
        public List<Terrain> Terrains { get; set; }

    }
}
