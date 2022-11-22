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

        Player player;

        // This offset allows for camera movement without a programmed camera class
        public Vector3 spriteBatchOffset;

        public SceneManager SceneManager = new SceneManager();

        

        public MainProgram()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // sceneManager makes a new list of objects 
            sceneManager = new SceneManager();

            player = new Player();

            sceneManager.addEntity(player);

            RegisterComponents();

            base.Initialize();

            _graphics.PreferMultiSampling = true;




        }

        public void RegisterComponents()
        {
            // Registers all the components of each entity on scene load / startup
            foreach (Entity entity in sceneManager.scene)
            {
                ColliderSystem.Register(entity.GetComponent<Collider>());
                AnimatedSpriteSystem.Register(entity.GetComponent<AnimatedSprite>());
                TransformSystem.Register(entity.GetComponent<Transform>());
                SpriteSystem.Register(entity.GetComponent<Sprite>());
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadSprites();

            // TODO: use this.Content to load your game content here
        }

        public void LoadSprites()
        {
            // Loads both types of sprite components
            Sprite sprite;
            AnimatedSprite animatedSprite;
            foreach (Entity entity in sceneManager.scene)
            {
                sprite = entity.GetComponent<Sprite>();
                animatedSprite = entity.GetComponent<AnimatedSprite>();

                if (sprite != null)
                {
                    sprite.texture = Content.Load<Texture2D>(sprite.texAdress);
                }
                else if (animatedSprite != null)
                {
                    animatedSprite.texture = Content.Load<Texture2D>(animatedSprite.texAdress);
                    animatedSprite.FullyLoaded();

                }
            }
        }

        protected override void Update(GameTime gameTime)
        {
            TransformSystem.Update(gameTime);

            // Put code for movement here
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                sceneManager.saveScene("TestSave");
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.L))
            {
                sceneManager.loadScene("TestSave");
                LoadSprites();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);

            // SamplerState.PointWrap makes it so that you can scale pixel art without it getting compressed
            _spriteBatch.Begin(0, null, SamplerState.PointWrap, null, null, null, Matrix.CreateTranslation(spriteBatchOffset));

            foreach (Entity entity in sceneManager.scene)
            {
                _spriteBatch.Draw(entity.GetComponent<AnimatedSprite>().texture, entity.GetComponent<Transform>().position, entity.GetComponent<AnimatedSprite>().sourceRect, Color.White);
            }


            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
//fuck yeah