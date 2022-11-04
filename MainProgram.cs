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

        Texture2D limeTex;

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

            
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            limeTex = Content.Load<Texture2D>("Sprites/lime2");

            sceneManager.currentScene.sceneObjects.Add("lime", new Object(Vector2.Zero, 0f, limeTex, "lime", new Rectangle(0, 0, limeTex.Width, limeTex.Height), Color.White, Vector2.Zero, SpriteEffects.None, 0, 2f));

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {


            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                sceneManager.saveScene("egg.fuck");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.L))
            {
                sceneManager.loadScene("scene1");
            }

            Object lime;
            sceneManager.currentScene.sceneObjects.TryGetValue("lime", out lime);
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                lime.position.Y -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                lime.position.Y += 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                lime.position.X -= 5;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                lime.position.X += 5;
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