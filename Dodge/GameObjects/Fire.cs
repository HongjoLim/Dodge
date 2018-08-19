using System.Configuration;
using System.Drawing;

namespace Dodge.GameObjects
{
    public class Fire : GameObject
    {
        public Fire()
        {
            this._image_path = ConfigurationManager.AppSettings["Fire"];
            this._width = Form1.OBJECT_WIDTH;
            this._height = Form1.OBJECT_HEIGHT;
            this._appearance = new Bitmap(Image.FromFile(_image_path), _width, _height);
        }
    }
}
