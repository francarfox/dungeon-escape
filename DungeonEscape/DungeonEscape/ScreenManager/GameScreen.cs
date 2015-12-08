using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonEscape
{
    class GameScreen : Screen
    {
        public static Camera camera;
        public static Level level;
        public static Effect mainEffect;
        public static MouseState oldState;

        public static Player player;

        public override void Init()
        {
            HideMouse();

            camera = new Camera();
            mainEffect = Basic.content.Load<Effect>("MainEffect");
            level = new Level(1);

            player = new Player();
        }

        public override void Update()
        {
            level.Update();
            camera.Update();

            player.Update();

            oldState = Mouse.GetState();
        }

        public override void Render()
        {
            level.Render();
            player.Render();
        }
    }
}
