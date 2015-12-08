using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonEscape
{
    delegate void OnClick();

    class Button
    {
        Rectangle rectangle;
        String text;

        bool hover;

        MouseState oldState;
        OnClick clickFunction;

        public Button(int x, int y, int width, int height, String text, OnClick clickFunction)
        {
            rectangle = new Rectangle(x, y, width, height);
            this.text = text;
            this.clickFunction = clickFunction;
        }

        public void Update()
        {
            MouseState mState = Mouse.GetState();

            hover = rectangle.Contains(new Point(mState.X, mState.Y));

            if (hover && mState.LeftButton == ButtonState.Pressed && oldState.LeftButton == ButtonState.Released)
                clickFunction();
                
            oldState = mState;
        }

        public void Render()
        {
            Canvas.DrawBorder(7, rectangle, hover ? Color.Yellow : Color.White);

            Basic.spriteBatch.DrawString(Basic.mainFont, text, new Vector2(rectangle.X + rectangle.Width / 2 - Basic.mainFont.MeasureString(text).X / 2, rectangle.Y + rectangle.Height / 2 - Basic.mainFont.MeasureString(text).Y / 2), hover ? Color.Yellow : Color.White);
        }
    }
}
