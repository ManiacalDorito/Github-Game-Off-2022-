using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text.Json;


namespace Game_Jam_Game
{
    
    internal class SceneManager
    {
        public Scene currentScene;

        

        public SceneManager()
        {
            currentScene = new Scene("Scene!");
        }

        public void loadScene(string fileName)
        {
            Stream stream = null;

            // Catches errors if the scene name is mispelled or the file cant be found
            try
            {
                stream = File.OpenRead(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            JsonSerializerOptions options = new JsonSerializerOptions();

            // Deserializes the saved scene and puts it into currentScene to be loaded and shit
            currentScene = JsonSerializer.Deserialize<Scene>(stream, options);

        }

        public void saveScene(string fileName)
        {
            Stream stream = null;

            // Catches errors if the scene name is mispelled or the file cant be found
            try
            {
                stream = File.OpenWrite(fileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            JsonSerializerOptions options = new JsonSerializerOptions();

            // Saves current scene to file specified for loading later  
            JsonSerializer.Serialize(stream, currentScene, options);
            Console.Write("Saved to: " + stream);
            stream.Close();
        }
    }
}
