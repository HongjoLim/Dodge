using System.Configuration;
using System.Drawing;

namespace Dodge.GameObjects
{
    /// <summary>
    /// 
    /// Name:       Jo Lim
    /// Date:         Aug 8 2018
    /// Purpose:    This class is for the flash that the player shoots
    /// 
    /// </summary>

    public class Flash : GameObject
    {
        public int MovingDirection { get; set; }
        public Flash()
        {
            this._image_path = ConfigurationManager.AppSettings["BasicFlash"];
            this._width = Form1.OBJECT_WIDTH/2;
            this._height = Form1.OBJECT_HEIGHT/2;
            this._appearance = new Bitmap(Image.FromFile(_image_path), _width, _height);
            this.Speed = 10;
        }

        public void Move()
        {
            switch (this.MovingDirection)
            {
                case Player.MOVE_UP:
                    this.PosY -= this.Speed;
                    break;
                case Player.MOVE_DOWN:
                    this.PosY += this.Speed;
                    break;
                case Player.MOVE_LEFT:
                    this.PosX -= this.Speed;
                    break;
                case Player.MOVE_RIGHT:
                    this.PosX += this.Speed;
                    break;
            }
        }
    }
}
