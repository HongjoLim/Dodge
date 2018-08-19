using Dodge.Util;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;

namespace Dodge.GameObjects
{
    /// <summary>
    /// Name:       Jo Lim
    /// Date:         Aug 8 2018
    /// Purpose:    This class is to store a player object
    /// </summary>

    public class Player : GameObject
    {
        #region - Constants to tell where the player is heading
        public const int MOVE_UP = 1;
        public const int MOVE_DOWN = 2;
        public const int MOVE_LEFT = 3;
        public const int MOVE_RIGHT = 4;
        #endregion

        public int MovingDirection { get; set; }

        private List<Flash> flashes = new List<Flash>();
        public List<Flash> Flashes {get{return this.flashes;} set { this.flashes = value; } }

        // Private constructor to make this class Singleton
        public Player()
        {
            // Change the speed to move player faster or slower
            this.Speed = 15;
            this._image_path = ConfigurationManager.AppSettings["Player"];
            this._width = Form1.OBJECT_WIDTH;
            this._height = Form1.OBJECT_HEIGHT;
            this.Health = 100;
            this._appearance = new Bitmap(Image.FromFile(_image_path), _width, _height);
        }
        public void MoveLeft() { if (this.PosX <= 0) { this.PosX = 0; } this.PosX -= Speed;}

        public void MoveRight() {this.PosX += Speed;}
        public void MoveUp(){ if (this.PosY <= 0) { this.PosY = 0; } this.PosY -= Speed;}

        public void MoveDown(){this.PosY += Speed;}
        
        public void Shoot()
        {
            var flash = (Flash) GameObjectMaker.CreateObject(GameObjectMaker.FLASH);

            #region - set basic properties of a flash

            flash.PosX = this.PosX+this.Width/4;
            flash.PosY = this.PosY+this.Height/4;
            flash.MovingDirection = this.MovingDirection;

            #endregion

            this.flashes.Add(flash);
        }
    }
}
