using System.Configuration;
using System.Drawing;

namespace Dodge.GameObjects
{
    /// <summary>
    /// Name:       Jo Lim
    /// Date:         Aug 8 2018
    /// Purpose:    This class is to store an enemy object
    /// </summary>

    public class BasicEnemy : GameObject
    {
        // NOT using enum to save memory
        public const int TYPE_ENEMY1 = 1;
        public const int TYPE_ENEMY2 = 2;

        // The constructor takes an integer value for the enemie's type

        public BasicEnemy(int type)
        {
            // If the value of the parameter matches with 'TYPE_ENEMY1', generate type1 enemy
            if (type == TYPE_ENEMY1)
            {
                // Get the image path string from the App.config file
                this._image_path = ConfigurationManager.AppSettings["BasicEnemy1"];
            }
            else
            {
                this._image_path = ConfigurationManager.AppSettings["BasicEnemy2"];
            }
            this.Health = 20;
            this._width = Form1.OBJECT_WIDTH;
            this._height = Form1.OBJECT_HEIGHT;
            this._appearance = new Bitmap(Image.FromFile(_image_path), _width, _height);
        }
    }
}
