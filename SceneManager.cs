using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;


namespace Game_Jam_Game
{
    
    internal class SceneManager
    {
        public Scene currentScene;


        public SceneManager()
        {
            currentScene = new Scene("Scene!");
        }

        public void addObject(string name, Object obj)
        {
            currentScene.sceneObjects.Add(name, obj);
        }

        public void loadScene(string fileName)
        {

            // Catches errors if the scene name is mispelled or the file cant be found
            try
            {
                // Makes a reader, reads the file and saves it to string json
                StreamReader sr = new StreamReader(fileName);
                string json = sr.ReadToEndAsync().Result;

                
                // converts from json string to Scene object
                currentScene = JsonConvert.DeserializeObject<Scene>(json);

            
                sr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            

        }

        public void saveScene(string fileName)
        {

            // Catches errors if it can't save for some reason
            try
            {
                StreamWriter writer = new StreamWriter(fileName);
                JsonSerializerSettings settings = new JsonSerializerSettings();

                writer.Write(JsonConvert.SerializeObject(currentScene, Formatting.Indented));
                
                Console.Write("Saved to: " + fileName);
                
                writer.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            
        }
    }
}
