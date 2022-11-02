using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Jam_Game
{
    internal class Object
    {
        Vector2 position;
        float rotation;
        Texture2D texture;
        string name;

        public Object(Vector2 position, float rotation, Texture2D texture, string name)
        {
            this.position = position;
            this.rotation = rotation;
            this.texture = texture;
            this.name = name;
        }
    }
}
