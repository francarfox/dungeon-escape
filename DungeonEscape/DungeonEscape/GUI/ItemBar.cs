using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonEscape
{
    class ItemBar
    {
        private int slots = 4;
        public int selectSlot = 0;

        public Texture2D[] items;
        public Texture2D selectedItem;

        public ItemBar()
        {
            items = new Texture2D[slots];
        }

        public void Update()
        {
            KeyboardState key = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();

            if (key.IsKeyDown(Keys.Down) || mouse.ScrollWheelValue < GameScreen.oldState.ScrollWheelValue)
                selectSlot++;
            if (key.IsKeyDown(Keys.Up) || mouse.ScrollWheelValue > GameScreen.oldState.ScrollWheelValue)
                selectSlot--;

            if (selectSlot < 0)
                selectSlot = slots - 1;
            if (selectSlot >= slots)
                selectSlot = 0;

            selectedItem = items[selectSlot];
        }

        public void Render()
        {
            for (int i = 0; i < slots; i++)
            {
                if (i == selectSlot)
                    Canvas.DrawBorder(5, new Rectangle(Basic.windowSize.Width - 110, 10 + i * 100, 100, 100), Color.White);
                else
                    Canvas.DrawBorder(5, new Rectangle(Basic.windowSize.Width - 110, 10 + i * 100, 100, 100), Color.Gray);

                if (items[i] != null)
                    Basic.spriteBatch.Draw(items[i], new Rectangle(Basic.windowSize.Width - 105, 15 + i * 100, 90, 90), Color.White);
            }
        }

        public bool SetItem(Texture2D texture)
        {
            for (int i = 0; i < slots; i++)
            {
                if (items[i] == null)
                {
                    items[i] = texture;
                    return true;
                }
            }

            return false;
        }

        public void RemoveSelectedItem()
        {
            items[selectSlot] = null;
        }
    }
}
