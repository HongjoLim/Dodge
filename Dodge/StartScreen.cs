using System;
using Dodge.Data;
using System.Windows.Forms;
using Dodge.Util;

namespace Dodge
{
    public partial class StartScreen : Form
    {
        private User user;

        #region - Constants for messages
        
        private const string REGISTER_ERROR_MESSAGE = 
            "Please use more than 7 letters for both User Name and Password";

        private const string REGISTER_SUCCESS_MESSAGE =
            "You have successfully registered! Please Log in!";

        private const string DATABASE_ERROR_MESSAGE =
            "Something must have gone wrong in the database!";

        private const string LOGIN_ERROR_MESSAGE =
            "Sign In Failed!";

        private const string LOGIN_SUCCESS_MESSAGE =
            "Welcome!";

        private const string INSTRUCTION = 
            "1. Move the player with 'UP', 'DOWN', 'LEFT', 'RIGHT' keys\n" +
            "2. To shoot the flash, press s button\n" +
            "3. To pause, press space bar\n" +
            "4. If the player gets to the fire, the player loses 1 health\n" +
            "5. If the flash hits the enemy, the enemy loses 5 health (20 health for enemy)\n" +
            "6. If the player gets every 300 points, the level increases\n" +
            "7. Loading game is NOT available yet!!";

        #endregion

        public StartScreen()
        { 
            InitializeComponent();
            this.Width = 800;
            this.Height = 400;

        }

        private void SignInBtn_Click(object sender, EventArgs e)
        {
            user = new User
            {
                UserName = UserNameText.Text,
                Password = UserPasswordText.Text
            };

            bool result = UserSignInTool.SignIn(user);

            if (result)
            {
                MemberPanel.Visible = true;
                this.InstructionText.Text = INSTRUCTION;
            }
            else
            {
                ShowMessage(LOGIN_ERROR_MESSAGE);
            }
            
        }

        private void SignUpBtn_Click(object sender, EventArgs e)
        {
            var userName = UserNameText.Text;
            var password = UserPasswordText.Text;

            if (userName.Trim().Length > 7 && password.Trim().Length > 7)
            {
                user = new User
                {
                    UserName = userName,
                    Password = password
                };

                bool result = UserRegisterTool.Register(user);
                if (result)
                {
                    ShowMessage(REGISTER_SUCCESS_MESSAGE);
                }
                else
                {
                    ShowMessage(DATABASE_ERROR_MESSAGE);
                }
            }
            else
            {
                // Using the custom method, show the message in the message box
                ShowMessage(REGISTER_ERROR_MESSAGE);
            }
        }

        // Custom method to show any message in the message box
        private void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        private void NewBtn_Click(object sender, EventArgs e)
        {
            var game = new Game();
            new Form1(game, new Util.KeyHandler(game), user).Show();
        }

        // This method is handling open file dialog event to load saved games
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            string fileName = openFileDialog1.FileName;
            try
            {
                // Load the saved data and put the information into GameData object
                GameData gamedata = GameJsonLoaderSaver.LoadGame(fileName);
                // Initialize Game object
                Game game = new Game()
                {
                    // Extracts essential data from GameData object puts it back into Game object
                    Level = gamedata.Level,
                    Player = gamedata.Player,
                    Score = gamedata.Score,
                    Terrains = gamedata.Terrains
                };

                new Form1(game, new Util.KeyHandler(game), gamedata.User).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot open file");
            }
        }
    }
}
