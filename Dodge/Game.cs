using Dodge.GameObjects;
using Dodge.Util;
using System.Collections.Generic;

namespace Dodge
{
    public class Game
    {
        public delegate void StartGame();
        public event StartGame StartGameEvent;

        // The constans to indicate the state of the game - NOT using enum just to save more memory
        public const int GAMESTATE_PAUSED = 1;
        public const int GAMESTATE_RUNNING = 2;
        public const int GAMESTATE_NOT_RUNNING = 3;
        
        public int State {get; set;}
        private int score = 0;
        public int Score { get { return score; }
            set
            {
                this.score = value;
                if (score % 300 == 0)
                {
                    // Whenever score gets new 300 points, increase the current level
                    Level++;
                }
            }
        }
        private int level = 1;
        public int Level { get { return this.level; }
            set
            {
                this.level = value;
            }
        }

        private List<Terrain> terrains;

        public List<Terrain> Terrains {
            get
            {return terrains;}
            set{ terrains = value;}
        }
        public Player Player { get; set; }
        private List<GameObject> fires = new List<GameObject>();
        public List<GameObject> Fires { get { return fires; } set { fires = value; } }

        private List<GameObject> enemies = new List<GameObject>();
        public List<GameObject> Enemies { get { return this.enemies; } set { this.enemies = value; } }
        
        // The default constructor
        public Game()
        {
            StartGameEvent += GetTerrain;
            StartGameEvent += CreatePlayer;
            StartGameEvent += GetEnemies;     
        }

        // This method starts the event to initialize components in the game(enemy, player, terrain etc..)
        public void Start()
        {
            this.State = GAMESTATE_RUNNING;
            if (Enemies.Count < 1)
            {
                StartGameEvent();
            }
        }

        // It just gets the instance of a Player object and assign it to the _player field
        private void CreatePlayer()
        {
            Player = new Player();
        }

        private void GetTerrain()
        {
            this.Terrains = TerrainMaker.Generate
                (Form1.NUM_OF_ROWS, Form1.NUM_OF_COLUMNS, Form1.WIDTH, Form1.HEIGHT);
        }

        /// <summary>
        ///     This method generates enemies.place them in the corresponding terrain
        ///     Each terrain has a type, and according to its type, different types of enemies are to be placed
        /// </summary>
        public void GetEnemies()
        {
            for (int i=0; i<terrains.Count; i++)
            {
                switch (terrains[i].TerrainType)
                {
                    // If the type of terrain is 'FIRE', then generate Fire class and place it in the terrain
                    case Terrain.TERRAINSTATE_FIRE:
                        var fire = GameObjectMaker.CreateObject(GameObjectMaker.FIRE);
                        fire.PosX = terrains[i].PosX;
                        fire.PosY = terrains[i].PosY;
                        //  Add the generated fire into the List<Fire> in this class
                        this.fires.Add(fire);
                        break;
                    // If the type of terrain is 'Enemy1', then generate Enemy(that has type of basic enemy1) class and place it in the terrain
                    case Terrain.TERRAINSTATE_ENEMY1:
                        var basic1 = GameObjectMaker.CreateObject(GameObjectMaker.BASIC1);
                        basic1.PosX = terrains[i].PosX;
                        basic1.PosY = terrains[i].PosY;
                        //  Add the generated enemy into the List<Enemy> in this class
                        enemies.Add(basic1);
                        break;
                    case Terrain.TERRAINSTATE_ENEMY2:
                        var basic2 = GameObjectMaker.CreateObject(GameObjectMaker.BASIC2);
                        basic2.PosX = terrains[i].PosX;
                        basic2.PosY = terrains[i].PosY;
                        enemies.Add(basic2);
                        break;
                }
            }
        }
    }
}
