using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Jam_Game
{
    public class Object
    {
        public Vector2 position;
        public float rotation;
        public Texture2D texture;
        public string name;
        public Rectangle sourceRect;
        public Color Color;
        public Vector2 origin;
        public SpriteEffects spriteEffects;
        public int layerDepth;
        public float scale;
        public Rectangle collisionRect;

        // Automatically creates the collisionRect from the sourceRect 

        /// <summary>
        /// Creates an object (default)
        /// </summary>
        /// <param name="position">the position of the object</param>
        /// <param name="rotation">the rotation of the object</param>
        /// <param name="texture">the texture to use</param>
        /// <param name="name">the name of the object</param>
        /// <param name="sourceRect">the sourceRect to use (if the texture is a sheet, if not put Rectangle.Empty)</param>
        /// <param name="color">the color of the object (idfk what this does just do white)</param>
        /// <param name="origin">object's origin point</param>
        /// <param name="spriteEffects">the spriteEffects to be applied</param>
        /// <param name="layerDepth">the layer depth of the object</param>
        /// <param name="scale">the scale of the object</param>
        public Object(Vector2 position, float rotation, Texture2D texture, string name, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.texture = texture;
            this.name = name;
            this.sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);
            this.collisionRect = this.sourceRect;
            this.Color = color;
            this.origin = origin;
            this.spriteEffects = spriteEffects;
            this.layerDepth = layerDepth;
            this.scale = scale;
        }

        /// <summary>
        /// Creates an object (source override)
        /// </summary>
        /// <param name="position">the position of the object</param>
        /// <param name="rotation">the rotation of the object</param>
        /// <param name="texture">the texture to use</param>
        /// <param name="name">the name of the object</param>
        /// <param name="sourceRect">the sourceRect to use (if the texture is a sheet, if not put Rectangle.Empty)</param>
        /// <param name="color">the color of the object (idfk what this does just do white)</param>
        /// <param name="origin">object's origin point</param>
        /// <param name="spriteEffects">the spriteEffects to be applied</param>
        /// <param name="layerDepth">the layer depth of the object</param>
        /// <param name="scale">the scale of the object</param>
        public Object(Vector2 position, float rotation, Texture2D texture, string name, Rectangle sourceRect, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.texture = texture;
            this.name = name;
            this.sourceRect = sourceRect;
            this.collisionRect = this.sourceRect;
            this.Color = color;
            this.origin = origin;
            this.spriteEffects = spriteEffects;
            this.layerDepth = layerDepth;
            this.scale = scale;
        }

        /// <summary>
        /// Creates an object (coll. override)
        /// </summary>
        /// <param name="position">the position of the object</param>
        /// <param name="rotation">the rotation of the object</param>
        /// <param name="texture">the texture to use</param>
        /// <param name="name">the name of the object</param>
        /// <param name="sourceRect">the sourceRect to use (if the texture is a sheet, if not put Rectangle.Empty)</param>
        /// <param name="color">the color of the object (idfk what this does just do white)</param>
        /// <param name="origin">object's origin point</param>
        /// <param name="spriteEffects">the spriteEffects to be applied</param>
        /// <param name="layerDepth">the layer depth of the object</param>
        /// <param name="scale">the scale of the object</param>
        /// <param name="collisionRect">the collision rectangle of the object</param>
        public Object(Vector2 position, float rotation, Texture2D texture, string name, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale, Rectangle collisionRect)
        {
            this.position = position;
            this.rotation = rotation;
            this.texture = texture;
            this.name = name;
            this.sourceRect = new Rectangle(0, 0, texture.Width, texture.Height);
            this.collisionRect = collisionRect;
            this.Color = color;
            this.origin = origin;
            this.spriteEffects = spriteEffects;
            this.layerDepth = layerDepth;
            this.scale = scale;
        }

        /// <summary>
        /// Creates an object (coll. + source override)
        /// </summary>
        /// <param name="position">the position of the object</param>
        /// <param name="rotation">the rotation of the object</param>
        /// <param name="texture">the texture to use</param>
        /// <param name="name">the name of the object</param>
        /// <param name="sourceRect">the sourceRect to use (if the texture is a sheet, if not put Rectangle.Empty)</param>
        /// <param name="color">the color of the object (idfk what this does just do white)</param>
        /// <param name="origin">object's origin point</param>
        /// <param name="spriteEffects">the spriteEffects to be applied</param>
        /// <param name="layerDepth">the layer depth of the object</param>
        /// <param name="scale">the scale of the object</param>
        /// <param name="collisionRect">the collision rectangle of the object</param>
        public Object(Vector2 position, float rotation, Texture2D texture, string name, Rectangle sourceRect, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale, Rectangle collisionRect)
        {
            this.position = position;
            this.rotation = rotation;
            this.texture = texture;
            this.name = name;
            this.sourceRect = sourceRect;
            this.collisionRect=collisionRect;
            this.Color = color;
            this.origin = origin;
            this.spriteEffects = spriteEffects;
            this.layerDepth = layerDepth;
            this.scale = scale;
        }


    }
}
