using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


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
            // Fucking FUCK FUCK FFUCK XML CANT SERIALIZE FUCKING DICTIONARIES
        }

        public void saveScene(string fileName)
        {
            
        }
    }
}
