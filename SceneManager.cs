using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Threading;


namespace Game_Jam_Game
{
    
    public class SceneManager
    {
        public List<Entity> scene;

        

        
        // Makes a new dictionary of the objects in the scene
        [JsonConstructor]
        public SceneManager()
        {
            scene = new List<Entity>();
            
        }

        // Adds a Entity to the scene
        public void addEntity(Entity entity)
        {
            scene.Add(entity);
            
        }

        public void removeEntity(Entity entity)
        {
            scene.Remove(entity);
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
                scene = JsonConvert.DeserializeObject<List<Entity>>(json);

                
            
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

                writer.Write(JsonConvert.SerializeObject(scene, Formatting.Indented));
                
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
