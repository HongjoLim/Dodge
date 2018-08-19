using System;
using System.Configuration;
using System.IO;
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
        public static void SaveGame(Game game, string fileName)
        {
            string s = JsonConvert.SerializeObject(game);

            try
            {
                if (File.Exists(fileName))
                {
                    fs = new FileStream(fileName, FileMode.Append);
                }
                else
                {
                    fs = new FileStream(fileName, FileMode.Create);
                }

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

        // This loading method DOES NOT WORK. I think because when I save the file in a text file with Json format, 
        // The file may not be appropriately flattened.
        public static Game LoadGame(string fileName)
        {
            string s="";
            try
            {
                fs = new FileStream(fileName, FileMode.Open);
                using (StreamReader sr = new StreamReader(fs))
                {
                    s = sr.ReadToEnd();
                }
                Game game = JsonConvert.DeserializeObject<Game>(s);
                return game;
            }
            catch (Exception e)
            {
                // TO DO: handle IOException
                return null;
            }
        }
    }
}
