using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game_Jam_Game
{
    // Marks scenes as serializable, making it so you can save and load from files
    [System.Serializable]
    public class Scene
    {
        public List<Object> SceneObjects { get; set; }
        public string name { get; set; }

        public Scene(string name)
        {
            SceneObjects = new List<Object>();
            this.name = name;
        }

        public Scene()
        {

        }
    }
}
