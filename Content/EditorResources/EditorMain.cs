using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace Game_Jam_Game.Content.EditorResources
{
    public class EditorMain
    {
        public List<Entity> editorEntities;
        public int editorDepth;
        int moveSpeed = 4;
        public int gridWidth = 50;
        public int gridHeight = 50;

        public void Update(GameTime time, ref Vector3 spritebatchOffset)
        {
            Debug.Write(spritebatchOffset);
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                spritebatchOffset.Y += -moveSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                spritebatchOffset.Y += moveSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                spritebatchOffset.X += -moveSpeed;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                spritebatchOffset.X += moveSpeed;
            }
        }


        public Entity gridPart = new Entity();
        

        public void Initialize()
        {

            Debug.WriteLine("init editor complete");
            editorEntities = new List<Entity>();



            gridPart.components.Add(new Transform(0, new Vector2(0,0), Vector2.One, 0f));
            gridPart.components.Add(new Sprite());
            

            gridPart.GetComponent<Sprite>().texAdress = "EditorResources/EditorSprites/EditorGrid";

            for (int i = 0; i < gridHeight; i++)
            {
                for (int k = 0; k < gridWidth; k++)
                {
                    Entity gridPartCloned = gridPart.clone();
                    gridPartCloned.GetComponent<Transform>().position.Y = i;
                    gridPartCloned.GetComponent<Transform>().position.X = k;
                    gridPartCloned.GetComponent<Sprite>().color= Color.White;
                    editorEntities.Add(gridPartCloned);
                    
                }
            }
            
            
        }
    }
}
