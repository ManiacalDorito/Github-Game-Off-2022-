using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
     
namespace Game_Jam_Game
{
    public class MainProgram : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SceneManager sceneManager;
        private Camera2D camera = new Camera2D();





        public MainProgram()
        {
            _graphics = new GraphicsDeviceManager(this);
            
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // sceneManager has a scene in it, just do sceneManager.currentscene to get the current level
            sceneManager = new SceneManager();
            base.Initialize();

            _graphics.PreferMultiSampling = true;


           

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            sceneManager.addObject("player", new Object(new Vector3(_graphics.PreferredBackBufferWidth/2, _graphics.PreferredBackBufferHeight/2, 0), 0f, "Sprites/lime", Color.White, Vector2.Zero, SpriteEffects.None, 0, 4f));

            sceneManager.addAnimatedObject("TestPlayer", new AnimatedObject(new Vector2(_graphics.PreferredBackBufferWidth / 2, _graphics.PreferredBackBufferHeight / 2), Vector2.Zero, "Sprites/testSheetFuck", 0f, 0.5f, 1f, Color.White, 0, SpriteEffects.None, 8));
            AnimatedObject player = sceneManager.currentScene.animatedSceneObjects["TestPlayer"];

            sceneManager.GetAnimArray("TestPlayer").Add(new Rectangle[]
            {
                new Rectangle(0, 0, 100, 100),
                new Rectangle(200, 0, 100, 100)
            });

            player.SetCurrentAnimArray(0);

            HandleObjectLoad();

            // TODO: use this.Content to load your game content here
        }

        private void HandleObjectLoad()
        {
            foreach (KeyValuePair<string, Object> kvp in sceneManager.currentScene.sceneObjects)
            {
                kvp.Value.texture = Content.Load<Texture2D>(kvp.Value.texAdress);
                if (kvp.Value.sourceRect == Rectangle.Empty)
                {
                    kvp.Value.sourceRect = new Rectangle(0, 0, kvp.Value.texture.Width, kvp.Value.texture.Height);
                }
            }

            foreach (KeyValuePair<string, AnimatedObject> kvp in sceneManager.currentScene.animatedSceneObjects)
            {
                kvp.Value.spriteSheet = Content.Load<Texture2D>(kvp.Value.texAdress);
            }
        }



        protected override void Update(GameTime gameTime)
        {


            // Handles input and player movement
            Object player;
            sceneManager.currentScene.sceneObjects.TryGetValue("player", out player);

            AnimatedObject test;
            sceneManager.currentScene.animatedSceneObjects.TryGetValue("TestPlayer", out test);

            
            test.UpdateSourceRect(gameTime);
            test.looping = false;

            // Put code for movement here
            PlayerMovement();

            // Code for camera movement
            CameraMovement(test);

            base.Update(gameTime);

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);

            // SamplerState.PointWrap makes it so that you can scale pixel art without it getting compressed
            _spriteBatch.Begin(0, null, SamplerState.PointWrap, null, null, null, Matrix.CreateTranslation(camera.Position)) ;
            
            // Draws all objects in the scene object list
            foreach (KeyValuePair<string, Object> obj in sceneManager.currentScene.sceneObjects)
            {
                _spriteBatch.Draw(obj.Value.texture, new Vector2(obj.Value.position.X, obj.Value.position.Y), obj.Value.sourceRect, obj.Value.Color, obj.Value.rotation, obj.Value.origin, obj.Value.scale, obj.Value.spriteEffects, obj.Value.layerDepth);
            }

            foreach (KeyValuePair<string, AnimatedObject> obj in sceneManager.currentScene.animatedSceneObjects)
            {
                _spriteBatch.Draw(obj.Value.spriteSheet, obj.Value.position, obj.Value.sourceRectangle, obj.Value.color, obj.Value.rotation, obj.Value.origin, obj.Value.scale, obj.Value.spriteEffects, obj.Value.layerDepth);
            }


            _spriteBatch.End();


            base.Draw(gameTime);
        }




        //-----------------------------------------------------------------------------------------------------------
        // ALL METHODS AFTER THIS LINE ARE CALLED IN UPDATE, THIS IS FOR ORGANIZATION AND SIMPLIFICATION OF THIS SHIT
        //-----------------------------------------------------------------------------------------------------------


        private void CameraMovement(Object player)
        {
            camera.Position = new Vector3(-player.position.X + _graphics.PreferredBackBufferWidth / 2 - (player.texture.Width / 2) * player.scale, -player.position.Y + _graphics.PreferredBackBufferHeight / 2 - (player.texture.Height / 2) * player.scale, -player.position.Z);
        }

        private void CameraMovement(AnimatedObject player)
        {
            camera.Position = new Vector3(-player.position.X + _graphics.PreferredBackBufferWidth / 2 - (player.sourceRectangle.Width / 2) * player.scale, -player.position.Y + _graphics.PreferredBackBufferHeight / 2 - (player.sourceRectangle.Height / 2) * player.scale, 0);
        }

        private Object PlayerMovement()
        {
            Object player;
            sceneManager.currentScene.sceneObjects.TryGetValue("player", out player);
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {

                player.position.Y -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                player.position.Y += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                player.position.X -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                player.position.X += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                sceneManager.saveScene("egg.scene");
            }
            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {
                sceneManager.loadScene("egg.scene");
                HandleObjectLoad();
            }

            return player;
        }






    }
}
//fuck yeah