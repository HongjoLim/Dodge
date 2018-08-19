using Dodge.Data;
using Dodge.Util;
using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft;

namespace Dodge
{
    public partial class Form1 : Form
    {
        private Game Game { get; set; }
        private KeyHandler handler;
        private User user;

        public const int NUM_OF_ROWS = 8;
        public const int NUM_OF_COLUMNS = 8;

        public const int WIDTH = 800;
        public const int HEIGHT = 800;

        public const int OBJECT_HEIGHT = WIDTH / NUM_OF_ROWS;
        public const int OBJECT_WIDTH = WIDTH / NUM_OF_COLUMNS;

        private delegate void UpdateInfo();
        private event UpdateInfo updateInfo;

        private delegate void UpdateObjects();
        private event UpdateObjects updateObjects;

        // Offset to be used when detecting a collision
        private const int OFFSET = 20;

        public Form1(Game game, KeyHandler handler, User user)
        {
            this.Game = game;
            this.handler = handler;
            this.user = user;

            #region - Add custom methods to the existing Paint event
            // Add the methods to the event
            this.Paint += DrawTerrain;
            this.Paint += DrawGameObjects;
            #endregion

            #region - Initializing the updating events (information, game objects)
            //Initialize the customized event to set the information on the upper-left screen

            updateInfo = new UpdateInfo(this.SetLevel);
            updateInfo += this.SetUserName;
            updateInfo += this.SetScore;
            updateInfo += this.SetHp;
            updateInfo += this.SetPause;

            updateObjects = new UpdateObjects(this.DetectFlashCollision);
            updateObjects += this.DetectPlayerFireCollision;
            updateObjects += this.ClearObjects;

            #endregion

            InitializeComponent();
        }

        #region - Methods for Update information on the left-upper side of the game screen
        public void SetLevel()
        {
            LevelText.Text = String.Format($"LEVEL: {Game.Level}");
        }

        private void SetUserName()
        {
            UserNameText.Text = String.Format($"USER NAME: {user.UserName}");
        }

        public void SetScore()
        {
            ScoreText.Text = String.Format($"SCORE: {Game.Score}");
        }

        private void SetHp()
        {
            HpText.Text = String.Format($"HP: {Game.Player.Health}");
        }

        private void SetPause()
        {
            if (Game.State != Game.GAMESTATE_PAUSED)
            {
                SaveBtn.Visible = false;
                PauseText.Visible = false;
                ContinueBtn.Visible = false;
                this.Focus();
                return;
            }

            SaveBtn.Visible = true;
            ContinueBtn.Visible = true;
            PauseText.Visible = true;
        }

        #endregion

        private void StartGame(object sender, EventArgs e)
        {
            this.Game.Start();
        }

        private void DrawTerrain(object sender, PaintEventArgs e)
        {
            var terrains = this.Game.Terrains;

            var pen = new Pen(Color.Black);
            var horizontalSpace = OBJECT_WIDTH;
            var verticalSpace = OBJECT_HEIGHT;

            // Draw Vertical Lines
            for (int i = 0; i < NUM_OF_COLUMNS; i++)
            {
                e.Graphics.DrawLine(pen, i * horizontalSpace, 0, i * horizontalSpace, this.Height);
            }

            // Draw Horizontal Lines
            for (int i = 0; i < NUM_OF_ROWS; i++)
            {
                e.Graphics.DrawLine(pen, 0, i * verticalSpace, this.Width, i * verticalSpace);
            }
        }

        private void DrawGameObjects(object sender, PaintEventArgs e)
        {
            // Draw the enemies
            var enemies = this.Game.Enemies;
            foreach (var enemy in enemies)
            {
                e.Graphics.DrawImage(enemy.Appearance, enemy.PosX, enemy.PosY);
            }

            // Draw the fires (fires cannot be removed - do not have health, so do not lose health when they get hit by flash)
            var fires = this.Game.Fires;
            foreach (var fire in fires)
            {
                e.Graphics.DrawImage(fire.Appearance, fire.PosX, fire.PosY);
            }

            // Draw the player
            var player = this.Game.Player;
            e.Graphics.DrawImage(player.Appearance, player.PosX, player.PosY);

            // Draw the flashes
            var flashes = player.Flashes;
            foreach (var flash in flashes)
            {
                e.Graphics.DrawImage(flash.Appearance, flash.PosX, flash.PosY);
                flash.Move();
            }
        }

        // Handles keydown event/
        private void KeyDownEvent(object sender, KeyEventArgs e)
        {
            this.handler.Handle(e);
        }

        // This method is for the timer tick event (100 milliseconds interval for renew) 
        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();

            if (this.Game.State != Game.GAMESTATE_NOT_RUNNING)
            {
                if (GameoverText.Visible) { GameoverText.Visible = false; }
                // Start the object update events
                updateObjects();

                // Start the event to renew the information on the upper-left side of the screen
                updateInfo();
            }
            else
            {
                GameoverText.Visible = true;
            }
        }

        #region - Code for enemy - flash collision

        private void DetectFlashCollision()
        {
            
            var player = this.Game.Player;

            // If the flash hits an enemy, the enemy loses health by 5
            var flashes = player.Flashes;
            var enemies = this.Game.Enemies;

            for (int i = 0; i < flashes.Count; i++)
            {
                var flashRec = new Rectangle(flashes[i].PosX, flashes[i].PosY, flashes[i].Width - OFFSET, flashes[i].Height - OFFSET);
                for (int j = 0; j < enemies.Count; j++)
                {
                    var enemyRec = new Rectangle(enemies[j].PosX, enemies[j].PosY, enemies[j].Width - OFFSET, enemies[j].Height - OFFSET);

                    if (flashRec.IntersectsWith(enemyRec))
                    {
                        enemies[j].Health -= 5;
                        this.Game.Score += 10;

                        // Exception is thrown in this block. I do not know why exactly
                        try
                        {
                            flashes.Remove(flashes[i]);
                            this.Game.Player.Flashes = flashes;
                        }
                        catch
                        {
                            // Just go out of the loop
                            break;
                        }
                    }
                }
            }
        }
        #endregion

        private void DetectPlayerFireCollision()
        {
            var player = this.Game.Player;

            // If the player intersects with the fire, the player loses his health by 5

            var playerRec = new Rectangle(player.PosX, player.PosY, player.Width - OFFSET, player.Height - OFFSET);

            var fires = this.Game.Fires;
            foreach (var fire in fires)
            {
                var fireRec = new Rectangle(fire.PosX, fire.PosY, fire.Width - OFFSET, fire.Height - OFFSET);
                if (playerRec.IntersectsWith(fireRec))
                {
                    player.Health -= 1;
                }
            }
        }

        private void ClearObjects()
        {
            var enemies = this.Game.Enemies;
            // Clear out the dead Enemies

            var deads = enemies.Find(x => x.Health <= 0);
            enemies.Remove(deads);
            deads = null;

            // Set new sets of enemies in the Game class
            this.Game.Enemies = enemies;

            if (this.Game.Player.Health <= 0)
            {
                this.Game.State = Game.GAMESTATE_NOT_RUNNING;
                enemies.Clear();

                // Call the method to show EXIT & Try Again buttons
                ToggleButtons();
            }
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void TryAgainBtn_Click(object sender, EventArgs e)
        {
            // Start a new game
            this.Game = new Game();

            // Set a new game on the handler
            this.handler.Game = this.Game;
            this.Game.Start();
            
            // Erase all the buttons
            ToggleButtons();

            // Give the form the focus (if not, the keydown event will not fire) 
            this.Focus();
        }

        //  This method is to toggle Exit Button & Try Again Button
        private void ToggleButtons()
        {
            if (ExitBtn.Visible == true)
            {
                ExitBtn.Visible = false;
                TryAgainBtn.Visible = false;
            }
            else
            {
                ExitBtn.Visible = true;
                TryAgainBtn.Visible = true;
            }
        }

        // This method handles saving the game event
        private void SaveBtn_Click(object sender, EventArgs e)
        {
            // Open up the save file dialog
            saveFileDialog1.ShowDialog();

            // Get the file name from the user
            string fileName = saveFileDialog1.FileName;

            // If the file name has not been entered, show the warning message and open the save file dialog again
            if (fileName.Trim().Length < 1)
            {
                MessageBox.Show("Please enter FileName");
                saveFileDialog1.ShowDialog();
            }

            // Using custom class 'GameJsonLoaderSaver', save the file into a text file that contains JSON string
            GameJsonLoaderSaver.SaveGame(this.Game, fileName);

            this.Game.State = Game.GAMESTATE_RUNNING;
            SetPause();

        }

        private void ContinueBtn_Click(object sender, EventArgs e)
        {
            this.Game.State = Game.GAMESTATE_RUNNING;
            SetPause();
        }
    }
}
