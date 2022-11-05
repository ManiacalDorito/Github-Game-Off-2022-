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
            Stream stream;
            stream = File.OpenRead(fileName);
            JsonSerializerOptions options = new JsonSerializerOptions();
            //currentScene = JsonSerializer.Deserialize(stream, Scene, options);

        }

        public void saveScene(string fileName)
        {
            Stream stream;
            stream = File.OpenWrite(fileName);
            JsonSerializerOptions options = new JsonSerializerOptions();
            JsonSerializer.Serialize(stream, currentScene, options);
            Console.Write("Saved to: " + stream);
            stream.Close();
        }
    }
}
