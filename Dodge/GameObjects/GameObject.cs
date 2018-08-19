using System.Drawing;
using System.Windows.Forms;

namespace Dodge.GameObjects
{
    /// <summary>
    /// 
    /// Name:       Jo Lim
    /// Date:         Aug 8 2018
    /// Purpose:    This abstract class is the superclass for every game object
    /// 
    /// </summary>
    
    public abstract class GameObject
    {
        // The path for the image of a game object
        protected string _image_path;

        protected int _width;
        protected int _height;

        public int Width { get {return  _width; } }
        public int Height { get { return _height; } }
        public int Speed { get; set; }

        // Must be initialized in the constructor of a child class
        protected Bitmap _appearance;

        // Image(Read-only)
        public Bitmap Appearance
        {
            get { return _appearance; }
        }

        // The x, y positions of a game object on the screen
        public int PosX {get; set;}
       
        public int PosY {get; set;}

        // The health of the object
        public int Health { get; set; }
        
    }
}
