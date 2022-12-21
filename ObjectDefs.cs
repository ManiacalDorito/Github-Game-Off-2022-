using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace Game_Jam_Game
{

    /// <summary>
    /// This is a general entity class. It contains info about its collider, position, source image, animation files (if any), and more
    /// </summary>
    public class Entity
    {   
        public string ID { get; set; }

        public List<Component> components = new List<Component>();


        public void AddComponent(Component component)
        {
           
            components.Add(component);
            
        }

        public void RemoveComponent(Component component)
        {
            components.Remove(component);
        }

        public Entity clone()
        {
            Entity clonedEnt = new Entity();
            clonedEnt.ID = ID + "_clone";
            List<Component> clonedComponents = new List<Component>();
            foreach (Component component in this.components)
            {
                clonedComponents.Add(component);
            }

            clonedEnt.components = clonedComponents;
            return clonedEnt;
        }

        // method for getting components, should be performant enough for now but can definitely be optimized? Dunno, apparently foreach is really fuckin fast
        public T GetComponent<T>() where T : Component
        {
            foreach (Component component in components)
            {
                if (component.GetType().Equals(typeof(T)))
                {
                    return (T)component;
                }
            }
            return null;
        }

        public bool HasComponent<T>()
        {
            foreach (Component comp in components)
            {
                if (comp.GetType() == typeof(T))
                {
                    return true;
                }
            }
            return false;
        }

    }


    public class Component
    {
        

        public virtual void Update(GameTime gameTime) { }

        public virtual void FullyLoaded() { }
    }

    // Makes a subclass of component
    class Transform : Component
    {
        public Vector2 position = Vector2.Zero;
        public Vector2 scale = Vector2.Zero;
        public float layerDepth = 0;
        public float rotation = 0;

        public Transform(int layerdepth, Vector2 position, Vector2 scale, float rotation)
        {
            this.layerDepth = layerdepth;
            this.position = position;
            this.scale = scale;
            this.rotation = rotation;
        }

        public Transform(int layerdepth)
        {
            this.layerDepth = layerdepth;
        }

    }

    class Sprite : Component
    {
        [JsonIgnore]
        public Texture2D texture;
        public Color color;
        public string texAdress { get; set; }

    }

    class Collider : Component
    {
        Rectangle colliderRect;


    }

    class SheetSprite : Component
    {
        public Texture2D texture;
        public Rectangle sourceRect;
        public string texAdress { get; set; }
        public Color color;

        private int sheetWidth;
        private int sheetHeight;

        private int frameWidth;
        private int frameHeight;

        public SheetSprite(string c_texAdress, int c_sheetWidth, int c_sheetHeight)
        {
            this.texAdress = c_texAdress;
            this.sheetHeight = c_sheetHeight;
            this.sheetWidth = c_sheetWidth;

            
        }

        public override void FullyLoaded()
        {
            this.frameWidth = texture.Width / sheetWidth;
            this.frameHeight = texture.Height / sheetHeight;
            this.SetFrame(0, 0);
        }

        // sets what part of the texture it draws from, for making animations
        public void SetFrame(int xPos, int yPos)
        {
            this.sourceRect = new Rectangle(0 + xPos * frameWidth, 0 + yPos * frameHeight, frameWidth, frameHeight);
        }
    }


}
