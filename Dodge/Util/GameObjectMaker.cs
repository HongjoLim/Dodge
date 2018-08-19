using Dodge.GameObjects;
using System;
using System.Configuration;

namespace Dodge.Util
{
    /// <summary>
    /// Name:       Jo Lim
    /// Date:         Aug 8 2018
    /// Purpose:    This class has a static method which generates different object.
    ///                  It has been designed to follow factory design pattern
    /// </summary>

    static class GameObjectMaker
    {
        // NOT using enum to save memory
        public const int PLAYER = 1;
        public const int BASIC1 = 2;
        public const int BASIC2 = 3;

        public const int FLASH = 4;
        public const int FIRE = 5;

        public static GameObject CreateObject(int type)
        {
            GameObject obj = null;

            switch (type)
            {
                case PLAYER:
                    obj = new Player();
                    break;
                case BASIC1:
                    obj = new BasicEnemy(BasicEnemy.TYPE_ENEMY1);
                    break;
                case BASIC2:
                    obj = new BasicEnemy(BasicEnemy.TYPE_ENEMY2);
                    break;
                case FLASH:
                    obj = new Flash();
                    break;
                case FIRE:
                    obj = new Fire();
                    break;
            }

            return obj;
        }
    }
}
