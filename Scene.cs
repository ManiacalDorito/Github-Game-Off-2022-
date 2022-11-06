using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Game_Jam_Game
{
    // Marks scenes as serializable, making it so you can save and load from files
    [System.Serializable]
    public class Scene
    {
        public Dictionary<string, Object> sceneObjects { get; set; }
        public string name { get; set; }

        [JsonConstructor]
        public Scene(string name)
        {
            sceneObjects = new Dictionary<string, Object>();
            this.name = name;
        }

    }
}
