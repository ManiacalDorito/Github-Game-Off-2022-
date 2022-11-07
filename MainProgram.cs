using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
     
namespace Game_Jam_Game
{
    public class MainProgram : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SceneManager sceneManager;
        private Camera2D camera = new Camera2D();
        Texture2D playerTex;
        Texture2D quitButtonTex;


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

            sceneManager.addObject("player", new Object(Vector3.Zero, 0f, playerTex, Color.White, Vector2.Zero, SpriteEffects.None, 0, 2f));

            sceneManager.addObject("quitButton", new Object(Vector3.Zero, 0f, quitButtonTex, Color.White, Vector2.Zero, SpriteEffects.None, 0, 1f));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            

            playerTex = Content.Load<Texture2D>("Sprites/lime2");

            quitButtonTex = Content.Load<Texture2D>("Sprites/QuitButton");

            // TODO: use this.Content to load your game content here
        }


        protected override void Update(GameTime gameTime)
        {

            // Handles input and player movement
            Object player;
            Object quitButton;
            sceneManager.currentScene.sceneObjects.TryGetValue("player", out player);
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                
                player.position.Y -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                player.position.Y += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                player.position.X -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
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
                LoadContent();
                sceneManager.currentScene.sceneObjects.TryGetValue("player", out player);
                sceneManager.currentScene.sceneObjects.TryGetValue("quitButton", out quitButton);
                player.texture = playerTex;
                quitButton.texture = quitButtonTex;
            }

            // Sets the camera position to the players position
            camera.Position = new Vector3(player.position.X / player.scale, player.position.Y / player.scale, player.position.Z/player.scale);

            Debug.WriteLine("P : " + player.position);
            Debug.WriteLine("C : " + camera.Position);
            Debug.WriteLine("C Matrix : " + Matrix.CreateTranslation(camera.Position).Translation);

            base.Update(gameTime);

        }

        

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // SamplerState.PointWrap makes it so that you can scale pixel art without it getting compressed
            _spriteBatch.Begin(0, null, SamplerState.PointWrap, null, null, null, Matrix.CreateTranslation(camera.Position)) ;
            

            foreach (KeyValuePair<string, Object> obj in sceneManager.currentScene.sceneObjects)
            {
                _spriteBatch.Draw(obj.Value.texture, new Vector2(obj.Value.position.X, obj.Value.position.Y), obj.Value.sourceRect, obj.Value.Color, obj.Value.rotation, obj.Value.origin, obj.Value.scale, obj.Value.spriteEffects, obj.Value.layerDepth);
            }

            
            _spriteBatch.End();


            base.Draw(gameTime);
        }

    }
}
//fuck yeah