using Dodge.GameObjects;
using System.Windows.Forms;

namespace Dodge.Util
{
    /// <summary>
    /// Name:       Jo Lim
    /// Date:         Aug 8 2018
    /// Purpose:    This class handles user's keyboard inputs
    /// </summary>
    public class KeyHandler
    {
        private Game game;
        public Game Game { get { return game; } set { this.game = value; } }
        public KeyHandler(Game game)
        {
            this.game = game;
        }

    /// <summary>
    ///     This method handles the KeyDownEvent from Form1 class
    ///     It takes a KeyEventArgs parameter and extracts information from it to tell which key has been down
    /// </summary>
    /// <param name="ke"></param>

        public void Handle(KeyEventArgs ke)
        {
            switch (ke.KeyCode)
            {
                // If following keys have been down, control the player
                case Keys.Left:
                case Keys.Right:
                case Keys.Up:
                case Keys.Down:
                case Keys.S:
                    ControlPlayer(ke);
                    break;

                    // If space bar key has been down, pause the game
                case Keys.Space:
                    if (game.State == Game.GAMESTATE_PAUSED)
                    {
                        game.State = Game.GAMESTATE_RUNNING;
                    }
                    else if (game.State == Game.GAMESTATE_RUNNING) {
                        game.State = Game.GAMESTATE_PAUSED;
                    }
                    break;

                    //If other keys have been down, ignore the event
                default:
                    return;
            }
        }

        private void ControlPlayer(KeyEventArgs ke)
        {
            var player = this.Game.Player;
            // If the game is not running, do not control the player
            if (game.State != Game.GAMESTATE_RUNNING)
            {
                return;
            }
            else
            {
                switch (ke.KeyCode)
                {
                    case Keys.Left:
                        player.MoveLeft();
                        player.MovingDirection = Player.MOVE_LEFT;
                        break;
                    case Keys.Right:
                        player.MoveRight();
                        player.MovingDirection = Player.MOVE_RIGHT;
                        break;
                    case Keys.Up:
                        player.MoveUp();
                        player.MovingDirection = Player.MOVE_UP;
                        break;
                    case Keys.Down:
                        player.MovingDirection = Player.MOVE_DOWN;
                        player.MoveDown();
                        break;
                    case Keys.S:
                        player.Shoot();
                        break;
                }
            }
        }
    }
}
