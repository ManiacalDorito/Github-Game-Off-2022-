using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.Xna.Framework.Content;

namespace Game_Jam_Game.Content.EditorResources
{
    public class EditorMain
    {
        public List<Entity> editorEntities;
        public int editorDepth;
        int moveSpeed = 2;
        public int gridWidth = 50;
        public int gridHeight = 50;
        bool EditorDebugDraw = false;
        public SpriteFont editorFont;
        public bool Enabled = true;

        Vector3 offset;
        double g_time;


        public void Update(GameTime time, ref Vector3 spritebatchOffset, int backbufferWidth, int backbufferHeight)
        {


            if (Enabled)
            {
                Transform InspectorBoxTransform = InspectorBox.GetComponent<Transform>();
                InspectorBoxTransform.position = new Vector2(backbufferWidth - (InspectorBox.GetComponent<Sprite>().texture.Width * InspectorBoxTransform.scale.X) - offset.X, 0 - offset.Y);


                // used for drawing stuff related to these
                offset = spritebatchOffset;
                g_time = time.TotalGameTime.TotalSeconds;

                // if f1 is pressed, show the debug info at top left
                if (Keyboard.GetState().IsKeyDown(Keys.F1)) { EditorDebugDraw = !EditorDebugDraw; }


                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    // Double Editor Cam if shift is pressed
                    moveSpeed = 4;
                }
                else
                {
                    moveSpeed = 2;
                }


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
        }


        public Entity gridPart = new Entity();
        public Entity InspectorBox = new Entity();


        public void Initialize()
        {

            Debug.WriteLine("///// init editor complete! /////");
            editorEntities = new List<Entity>();

            // Sets up the InspectorBox for editing properties of Entities.
            InspectorBox.AddComponent(new Sprite());
            InspectorBox.AddComponent(new Transform(1, Vector2.One, Vector2.One, 0f));
            InspectorBox.GetComponent<Sprite>().texAdress = "EditorResources/EditorSprites/EditorInspectorBox";
            editorEntities.Add(InspectorBox);

            // Sets up the grid for snapping.
            gridPart.components.Add(new Transform(0, new Vector2(0,0), Vector2.One, 0f));
            gridPart.AddComponent(new Sprite());
            gridPart.GetComponent<Sprite>().texAdress = "EditorResources/EditorSprites/EditorGrid";

            for (int i = 0; i < gridHeight; i++)
            {
                for (int k = 0; k < gridWidth; k++)
                {
                    Entity gridPartCloned =  gridPart.clone();
                    gridPartCloned.GetComponent<Transform>().position.Y = i * gridWidth;
                    gridPartCloned.GetComponent<Transform>().position.X = k;
                    gridPartCloned.GetComponent<Sprite>().color= Color.White;
                    editorEntities.Add(gridPartCloned);
                    
                }
            }
            
            
        }

        public void DrawEditor(ref SpriteBatch spriteBatch)
        {
            if (Enabled)
            {
                // Draws info at top left like total time elapsed, etc.
                if (EditorDebugDraw)
                spriteBatch.DrawString(editorFont, $"EDITOR OVERLAY\nEditor Camera Position: {offset.ToString()}\nRuntime: {g_time}", new Vector2(10 - offset.X, 0 - offset.Y), Color.Black);

                foreach (Entity entity in this.editorEntities)
                {
                    if (entity.HasComponent<SheetSprite>())
                    {
                        spriteBatch.Draw(entity.GetComponent<SheetSprite>().texture, entity.GetComponent<Transform>().position, entity.GetComponent<SheetSprite>().sourceRect, Color.White);
                    }
                    else if (entity.HasComponent<Sprite>())
                    {
                        spriteBatch.Draw(entity.GetComponent<Sprite>().texture, entity.GetComponent<Transform>().position, Color.White);

                    }
                }


            }
        }

        public void LoadEditor(ref ContentManager Content)
        {
            Sprite sprite;
            SheetSprite sheetSprite;

            
        }

    }
}
