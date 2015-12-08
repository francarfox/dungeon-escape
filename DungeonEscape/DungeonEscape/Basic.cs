using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;

namespace DungeonEscape
{
    class Basic
    {
        public static SpriteBatch spriteBatch;
        public static GraphicsDevice gDevice;
        public static GraphicsDeviceManager gManager;
        public static ContentManager content;
        public static GameTime gameTime;
        public static Game1 game;

        public static GameWindow window;
        public static Rectangle windowSize = new Rectangle(0, 0, 800, 500);
        public static Random random = new Random();

        public static Screen currentScreen;
        public static SpriteFont mainFont;

        public static SamplerState sampler;

        public static void Init(Game1 _game)
        {
            game = _game;
            gManager = _game.graphics;
            gDevice = gManager.GraphicsDevice;
            content = _game.Content;
            spriteBatch = new SpriteBatch(gDevice);
            window = _game.Window;

            //gManager.PreferredBackBufferWidth = windowSize.Width;
            //gManager.PreferredBackBufferHeight = windowSize.Height;
            gManager.ApplyChanges();

            Textures.LoadTextures();
            Sounds.LoadSounds();
            Canvas.SetUpCanvas();

            SetScreen(new MenuScreen());

            mainFont = content.Load<SpriteFont>("Font");

            sampler = new SamplerState();
            sampler.Filter = TextureFilter.Point;

            gDevice.SamplerStates[0] = sampler;
        }

        public static void Update(GameTime _gameTime)
        {
            gameTime = _gameTime;

            currentScreen.Update();
        }

        public static void Render()
        {
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.NonPremultiplied, SamplerState.PointClamp, DepthStencilState.Default, RasterizerState.CullCounterClockwise);

            gDevice.DepthStencilState = DepthStencilState.Default;  //solido, sin ver a traves
            gDevice.SamplerStates[0] = sampler;
            currentScreen.Render();

            spriteBatch.End();
        }

        public static void SetScreen(Screen newScreen)
        {
            currentScreen = newScreen;
            currentScreen.Init();
        }
    }
}
