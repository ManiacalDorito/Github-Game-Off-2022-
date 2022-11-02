using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Jam_Game
{
    public class Object
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

        public Object()
        {
            this.position = Vector2.Zero;
            this.rotation = 0;
            this.texture = null;
            this.name = null;
        }
    }
}
