using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;

namespace Game_Jam_Game
{
    [System.Serializable]
    public class Object
    {
        public Vector3 position;
        public float rotation;
        [JsonIgnore]
        public Texture2D texture;
        public Rectangle sourceRect;
        public Color Color;
        public Vector2 origin;
        public SpriteEffects spriteEffects;
        public int layerDepth;
        public float scale;
        public Rectangle collisionRect;

        // Automatically creates the collisionRect from the sourceRect 

        public Object()
        {
            this.position = new Vector3(0, 0, 0);
            this.rotation = 0f;
            this.texture = null;
            this.sourceRect = Rectangle.Empty;
            this.Color = Color.White;
            this.origin = Vector2.Zero;
            this.spriteEffects = SpriteEffects.None;
            this.layerDepth = 0;
            this.scale = 1f;
            this.collisionRect = Rectangle.Empty;
        }

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
        public Object(Vector3 position, float rotation, Texture2D texture, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.texture = texture;
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
        public Object(Vector3 position, float rotation, Texture2D texture, Rectangle sourceRect, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.texture = texture;
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
        public Object(Vector3 position, float rotation, Texture2D texture, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale, Rectangle collisionRect)
        {
            this.position = position;
            this.rotation = rotation;
            this.texture = texture;
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
        public Object(Vector3 position, float rotation, Texture2D texture, Rectangle sourceRect, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale, Rectangle collisionRect)
        {
            this.position = position;
            this.rotation = rotation;
            this.texture = texture;
            this.sourceRect = sourceRect;
            this.collisionRect=collisionRect;
            this.Color = color;
            this.origin = origin;
            this.spriteEffects = spriteEffects;
            this.layerDepth = layerDepth;
            this.scale = scale;
        }

        
    }

    public class Camera2D
    {
        public Camera2D()
        {
            Zoom = 1;
            Position = Vector3.Zero;
            Rotation = 0;
            Origin = Vector2.Zero;
            Position = Vector3.Zero;
        }

        public float Zoom { get; set; }
        public float moveSpeed { get; set; }
        public Vector3 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }

        public void Move(Vector3 direction)
        {
            Position += direction;
        }

        public void MoveSmooth(Vector3 direction)
        {
            Vector3.Lerp(Position, direction, Zoom);
        }

        public Matrix GetTransform()
        {
            var translationMatrix = Matrix.CreateTranslation(new Vector3(Position.X, Position.Y, 0));
            var rotationMatrix = Matrix.CreateRotationZ(Rotation);
            var scaleMatrix = Matrix.CreateScale(new Vector3(Zoom, Zoom, 1));
            var originMatrix = Matrix.CreateTranslation(new Vector3(Origin.X, Origin.Y, 0));

            return translationMatrix * rotationMatrix * scaleMatrix * originMatrix;
        }
    }
}
