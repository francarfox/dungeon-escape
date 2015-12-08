using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DungeonEscape
{
    class Player
    {
        public int health = 255;
        int hurtTime = 0;

        public ItemBar itemBar;

        public Player()
        {
            itemBar = new ItemBar();
        }

        public void Update()
        {
            itemBar.Update();
        }

        public void Render()
        {
            health = (int)MathHelper.Clamp(health, 0, 255);

            if (health == 0)
                //Respawn();
                Basic.SetScreen(new MenuScreen());

            if (Basic.random.Next(100) == 10)
                Hurt(10);

            Canvas.DrawBorder(7, new Rectangle(10, Basic.windowSize.Height - 90, 250, 70), Color.Black);
            Canvas.DrawRectangle(new Rectangle(17, Basic.windowSize.Height - 83, 236 - (int)MathHelper.Lerp(236, 0, health / 255.0f), 56), new Color(255 - health, health, 0));

            itemBar.Render();

            if (hurtTime > 0)
            {
                hurtTime--;
                Canvas.DrawRectangle(Basic.windowSize, new Color(255, 0, 0, 200));
            }
        }

        public void Respawn()
        {
            health = 255;
            GameScreen.camera.position.X = GameScreen.level.spawnX;
            GameScreen.camera.position.Z = GameScreen.level.spawnZ;

            Sounds.changeLevel.Play();
        }

        public void Hurt(int amount)
        {
            health -= amount;
            hurtTime = 10;
        }
    }
}
