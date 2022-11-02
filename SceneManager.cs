using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Game_Jam_Game
{
    internal class SceneManager
    {
        Scene currentScene;

        public SceneManager()
        {
            currentScene = null;
        }

        void loadScene(Scene toLoad)
        {
            // Load it from file, implement serializing
            currentScene = toLoad;
        }

        void saveScene()
        {
            // Gotta save it to file too fuck
        }
    }
}
