using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Game_Jam_Game.Content.EditorResources;

     
namespace Game_Jam_Game
{
    public class MainProgram : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SceneManager sceneManager;


        // This offset allows for camera movement without a programmed camera class
        public Vector3 spriteBatchOffset;

        public SceneManager SceneManager = new SceneManager();

        public EditorMain _Editor = new EditorMain();

        


        public MainProgram()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            // Change this to false when not launching editor, and everything will simply not load at all.
            _Editor.Enabled = true;

            if (_Editor.Enabled)
            {
                Window.AllowUserResizing = false;
                _Editor.Initialize();
            }
            

            // Initialize sceneManager for loading scenes and holding the list of objects in each scene
            sceneManager = new SceneManager();



            RegisterComponents();

            base.Initialize();

            _graphics.PreferMultiSampling = true;

            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;

            // Toggles fullscreen
           // _graphics.ToggleFullScreen();



        }

        public void RegisterComponents()
        {
            // Registers all the components of each entity on scene load / startup
            foreach (Entity entity in sceneManager.scene)
            {
                ColliderSystem.Register(entity.GetComponent<Collider>());
                AnimatedSpriteSystem.Register(entity.GetComponent<SheetSprite>());
                TransformSystem.Register(entity.GetComponent<Transform>());
                SpriteSystem.Register(entity.GetComponent<Sprite>());
            }
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LoadSprites();
            LoadFonts();
           
            
        }

        public void LoadFonts()
        {


        }

        public void LoadSprites()
        {
            // Loads both types of sprite components
            Sprite sprite;
            SheetSprite sheetSprite;

            if (_Editor.Enabled)
            {
                // Loads editor fonts
                _Editor.editorFont = Content.Load<SpriteFont>("EditorResources/EditorFonts/EditorFont");



                // Loads all the entities in the scene
                foreach (Entity entity in _Editor.editorEntities)
                {
                    sprite = entity.GetComponent<Sprite>();
                    sheetSprite = entity.GetComponent<SheetSprite>();

                    if (sprite != null)
                    {
                        sprite.texture = Content.Load<Texture2D>(sprite.texAdress);
                        sprite.FullyLoaded();
                    }
                    else if (sheetSprite != null)
                    {
                        sheetSprite.texture = Content.Load<Texture2D>(sheetSprite.texAdress);
                        sheetSprite.FullyLoaded();

                    }
                }
            }

            // Loads all the entities in the scene
            foreach (Entity entity in this.sceneManager.scene)
            {
                sprite = entity.GetComponent<Sprite>();
                sheetSprite = entity.GetComponent<SheetSprite>();

                if (sprite != null)
                {
                    sprite.texture = Content.Load<Texture2D>(sprite.texAdress);
                    sprite.FullyLoaded();
                }
                else if (sheetSprite != null)
                {
                    sheetSprite.texture = Content.Load<Texture2D>(sheetSprite.texAdress);
                    sheetSprite.FullyLoaded();

                }
            }
        }


        //-----------------------------------------------------------------------------------------------------------------------------

        protected override void Update(GameTime gameTime)
        {
            //TransformSystem.Update(gameTime);


            if (_Editor.Enabled)
            {
                _Editor.Update(gameTime, ref spriteBatchOffset, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight);
                
            }

            base.Update(gameTime);
        }


        //-----------------------------------------------------------------------------------------------------------------------------

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // SamplerState.PointWrap makes it so that you can scale pixel art without it getting compressed
            _spriteBatch.Begin(0, null, SamplerState.PointWrap, null, null, null, Matrix.CreateTranslation(spriteBatchOffset));


            // Draws all the sprites of the entities
            // IMPLEMENT CHECKING IF IT'S IN THE CAMERA'S VIEW TO LIMIT DRAW CALLS FOR PERFORMANCE
            foreach (Entity entity in sceneManager.scene)
            {
                if (entity.HasComponent<SheetSprite>())
                {
                    Transform transform = entity.GetComponent<Transform>();
                    Rectangle sourceRect = entity.GetComponent<SheetSprite>().sourceRect;
                    _spriteBatch.Draw(entity.GetComponent<SheetSprite>().texture, entity.GetComponent<Transform>().position, entity.GetComponent<SheetSprite>().sourceRect, Color.White);

                 /*   if (InsideScreen(transform, sourceRect, spriteBatchOffset))
                    {

                    }*/
                }
                else if (entity.HasComponent<Sprite>())
                {
                    _spriteBatch.Draw(entity.GetComponent<Sprite>().texture, entity.GetComponent<Transform>().position, Color.White);
                }

            }



            
            if (_Editor.Enabled)
            {
                _Editor.DrawEditor(ref _spriteBatch);
                
            }
            


            _spriteBatch.End();


            base.Draw(gameTime);
        }

        


        bool InsideScreen(Transform transform, Texture2D texture2D, Vector3 cameraPos)
        {
            // Checks if the object is within the screen, and draws it if it is
            // Goes from the top left origin, if custom origins are made update this code
            bool VisibleOnX = (texture2D.Width + transform.position.X - cameraPos.X < 0) && (texture2D.Width + transform.position.X + cameraPos.X > _graphics.PreferredBackBufferWidth);
            bool VisibleOnY = (texture2D.Height + transform.position.Y - cameraPos.Y < 0) && (texture2D.Height + transform.position.Y + cameraPos.Y > _graphics.PreferredBackBufferHeight);
            // Returns true if it is visible on the x and y axis
            return VisibleOnX && VisibleOnY;
        }

        bool InsideScreen(Transform transform, Rectangle sourceRect, Vector3 cameraPos)
        {
            bool VisibleOnX = (sourceRect.Width + transform.position.X - cameraPos.X < 0) && (sourceRect.Width + transform.position.X > _graphics.PreferredBackBufferWidth);
            bool VisibleOnY = (sourceRect.Height + transform.position.Y - cameraPos.Y < 0) && (sourceRect.Height + transform.position.Y + cameraPos.Y > _graphics.PreferredBackBufferHeight);
            // Returns true if it is visible on the x and y axis
            return VisibleOnX && VisibleOnY;
        }

    }
}
//fuck yeah