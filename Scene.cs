using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game_Jam_Game
{
    // Marks scenes as serializable, making it so you can save and load from files
    [System.Serializable]
    internal class Scene
    {
        List<Object> SceneObjects;

        public Scene()
        {
            SceneObjects = new List<Object>();
        }
    }
}
