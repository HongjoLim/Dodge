using System;
using System.Configuration;
using System.IO;
using Dodge.Data;
using Newtonsoft.Json;

namespace Dodge.Util
{
    /// <summary>
    /// Name:       Jo Lim
    /// Date:         Aug 19 2018
    /// Purpose:    This class is to transform game data into JSON string,
    ///                 then, load and save the JSON string into a text file
    /// </summary>

    static class GameJsonLoaderSaver
    {
        // Static class field to hold FileStream object
        private static FileStream fs;
        private static string file_path = ConfigurationManager.AppSettings["SavePath"];
        public static void SaveGame(GameData game, string fileName)
        {
            string s = JsonConvert.SerializeObject(game);

            try
            {
                fs = new FileStream(fileName, FileMode.Create);

                using (StreamWriter sr = new StreamWriter(fs))
                {
                    sr.WriteLine(s);
                }
            }
            catch (Exception e)
            {
                // TO DO: Handle Exception
            }
        }

        // This loading method returns GameData object(simplified version of Game class)
        public static GameData LoadGame(string fileName)
        {
            string s="";
            try
            {
                fs = new FileStream(fileName, FileMode.Open);
                using (StreamReader sr = new StreamReader(fs))
                {
                    s = sr.ReadToEnd();
                }
                GameData gamedata = JsonConvert.DeserializeObject<GameData>(s);
                return gamedata;
            }
            catch (Exception e)
            {
                // TO DO: handle IOException
                return null;
            }
        }
    }
}
