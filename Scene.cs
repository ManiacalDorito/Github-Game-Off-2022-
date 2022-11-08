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
        public List<Gui> guiObjects { get; set; }
        public List<BackgroundTile> backgroundTiles { get; set; }
        public string name { get; set; }

        [JsonConstructor]
        public Scene(string name)
        {
            sceneObjects = new Dictionary<string, Object>();
            guiObjects = new List<Gui>();
            backgroundTiles = new List<BackgroundTile>();
            this.name = name;
        }

    }
}
