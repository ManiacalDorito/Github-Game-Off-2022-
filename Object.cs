using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;


namespace Game_Jam_Game
{
    [System.Serializable]

    //-----------------------------------------------------------------------------------------------------------
    // THIS CLASS IS FOR GENERAL GAME OBJECTS, IT HAS LOTS OF CONSTRUCTORS SO DONT EVEN OPEN IT THERES A FUCKING REASON IT GOES FROM 14 LINES TO 157 FUCKING LINES
    //-----------------------------------------------------------------------------------------------------------
    public class Object
    {
        public Vector3 position;
        public float rotation;
        [JsonIgnore]
        public Texture2D texture;
        public Rectangle sourceRect;
        public string texAdress;
        public Color Color;
        public Vector2 origin;
        public SpriteEffects spriteEffects;
        public int layerDepth;
        public float scale;
        public Rectangle collisionRect;       

        // Automatically creates the collisionRect from the sourceRect 

        public Object(string texAdress)
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
        [JsonConstructor]
        public Object(Vector3 position, float rotation, string texAdress, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.texAdress = texAdress;
            this.sourceRect = Rectangle.Empty;
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
        public Object(Vector3 position, float rotation, string texAdress, Rectangle sourceRect, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale)
        {
            this.position = position;
            this.rotation = rotation;
            this.texAdress = texAdress;
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
        public Object(Vector3 position, float rotation, string texAdress, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale, Rectangle collisionRect)
        {
            this.position = position;
            this.rotation = rotation;
            this.texAdress = texAdress;
            this.sourceRect = Rectangle.Empty;
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
        public Object(Vector3 position, float rotation, string texAdress, Rectangle sourceRect, Color color, Vector2 origin, SpriteEffects spriteEffects, int layerDepth, float scale, Rectangle collisionRect)
        {
            this.position = position;
            this.rotation = rotation;
            this.texAdress= texAdress;
            this.sourceRect = sourceRect;
            this.collisionRect = collisionRect;
            this.Color = color;
            this.origin = origin;
            this.spriteEffects = spriteEffects;
            this.layerDepth = layerDepth;
            this.scale = scale;
        }

    }




    //-----------------------------------------------------------------------------------------------------------
    // THIS CLASS IS FOR THE CAMERA, SO THAT YOU CAN SET THE LOCATION AND ROTATION AND UPDATE THE SPRITEBATCH MATRIX WITH THE VALUES
    //-----------------------------------------------------------------------------------------------------------
    public class Camera2D
    {
        [JsonConstructor]
        public Camera2D()
        {
            Position = Vector3.Zero;
            Rotation = 0;
            Origin = Vector2.Zero;
        }

        public Vector3 Position { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }


    }




    //-----------------------------------------------------------------------------------------------------------
    // THIS CLASS IS FOR THE GUI, THIS CLASS IS NO DIFFERENT FROM A NORMAL OBJECT OTHER THAN IT HAS A HIGHER LAYER AND MOVES AGAINST THE CAMERA
    //-----------------------------------------------------------------------------------------------------------
    public class Gui
    {
        static Vector3 cameraPosition;
        Vector3 transform { get; set; }
        float scale { get; set; }
        [JsonIgnore]
        Texture2D texture { get; set; }
        string texAdress { get; set; }
        float rotation { get; set; }
        int layerheight { get; set; }

        [JsonConstructor]
        Gui(ref Vector3 cameraPosition, Vector3 transform, float scale, string texAdress, float rotation, int layerheight)
        {
            this.rotation = rotation;
            this.texAdress = texAdress;
            this.scale = scale;
            this.rotation = rotation;
            this.layerheight = layerheight;
            this.texture = null;

        }



    }

    public class BackgroundTile
    {

        Vector3 transform;
        float scale;
        [JsonIgnore]
        Texture2D texture;
        string textureAdress;


        [JsonConstructor]
        BackgroundTile()
        {

        }
    }
}
