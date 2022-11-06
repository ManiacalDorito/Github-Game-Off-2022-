using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Game_Jam_Game
{
    public class MainProgram : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SceneManager sceneManager;

        Texture2D playerTex;

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

            sceneManager.currentScene.sceneObjects.Add("player", new Object(Vector2.Zero, 0f, playerTex, "player", new Rectangle(0, 0, playerTex.Width, playerTex.Height), Color.White, Vector2.Zero, SpriteEffects.None, 0, 2f));


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            

            playerTex = Content.Load<Texture2D>("Sprites/lime2");
            


            // TODO: use this.Content to load your game content here
        }


        protected override void Update(GameTime gameTime)
        {


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            Object player;
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
                player.texture = playerTex;
            }

            


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointWrap, null, null);
            

            foreach (KeyValuePair<string, Object> obj in sceneManager.currentScene.sceneObjects)
            {
                _spriteBatch.Draw(obj.Value.texture, obj.Value.position, obj.Value.sourceRect, obj.Value.Color, obj.Value.rotation, obj.Value.origin, obj.Value.scale, obj.Value.spriteEffects, obj.Value.layerDepth);
            }


            _spriteBatch.End();

            
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

    }
}
//fuck yeah