using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;

namespace Game_Jam_Game
{
    public class AnimatedObject
    {
        // ---------------------------------------------------------
        // This works fucking PERFECTLY LETS FUCKING GOOOOOOOOOOOOOO
        // ---------------------------------------------------------

        [JsonIgnore]
        public Texture2D spriteSheet { get; set; }
        public Vector2 position { get; set; }
        public float rotation { get; set; }
        public float animDelay { get; set; }
        public Vector2 origin { get; set; }
        public Rectangle sourceRectangle { get; set; }
        public Rectangle collisionRectangle { get; set; }
        public float scale { get; set; }
        public bool animated { get; set; }
        public Color color { get; set; }
        public string texAdress { get; set; }
        
        public int layerDepth { get; set; }
        public SpriteEffects spriteEffects { get; set; }

        public List<Rectangle[]> sourceArray;
        public Rectangle[] currentAnimArray;

        public bool looping { get; set; }




        public int i = 0;

        [JsonConstructor]
        public AnimatedObject(Vector2 transform, Vector2 origin, string texAdress, float rotation, float animationSpeed, float scale, Color color, int layerDepth, SpriteEffects spriteEffects, int frameArrayHeight)
        {
            this.spriteSheet = null;
            this.position = transform;
            this.texAdress = texAdress;
            this.rotation = rotation;
            this.animDelay = animationSpeed;
            this.sourceRectangle = new Rectangle(0, 0, 10, 10);
            this.collisionRectangle = Rectangle.Empty;
            this.origin = origin;
            this.scale = scale;
            this.color = color;
            this.layerDepth = layerDepth;
            this.spriteEffects = spriteEffects;
            this.looping = true;
            this.sourceArray = new List<Rectangle[]>();
        }


        public void SetCurrentAnimArray(int listIndex)
        {
            currentAnimArray = sourceArray.ElementAt(listIndex);
        }


        public void AddRectangleArray(Rectangle[] rectangles)
        {
            this.sourceArray.Add(rectangles);
        }

        float timeSinceLast = 0f;

        public void UpdateSourceRect(GameTime time)
        {

            // Runs once, if ranOnce true and looping false just return

            timeSinceLast += (float)time.ElapsedGameTime.TotalSeconds;
            bool ranOnce = false;

            // If time elapsed is greater than delay between frames
            if (timeSinceLast >= animDelay && i < currentAnimArray.Length)
            {
                if (ranOnce && looping == false)
                {
                    return;
                }
                else
                {
                    timeSinceLast = 0f;
                    sourceRectangle = currentAnimArray[i];
                    i++;
                }

                
            }
            
            if (i == currentAnimArray.Length)
            {
                ranOnce = true;

                if (looping == true)
                {
                    i = 0;
                }
                
                
            }
            
        }

    }
}
