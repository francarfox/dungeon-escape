using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DungeonEscape
{
    class Canvas
    {
        private static Texture2D canvas;

        public static void SetUpCanvas()
        {
            Color[] tempData = new Color[1];
            tempData[0] = Color.White;

            canvas = new Texture2D(Basic.gDevice, 1, 1);
            canvas.SetData(tempData);
        }

        public static void DrawPixel(int x, int y, Color color)
        {
            Basic.spriteBatch.Draw(canvas, new Vector2(x, y), color);
        }

        public static void DrawRectangle(Rectangle rect, Color color)
        {
            Basic.spriteBatch.Draw(canvas, rect, color);
        }

        public static void DrawBorder(int borderLength, Rectangle rect, Color color)
        {
            for (int x = 0; x < rect.Width; x++)
            {
                for (int y = 0; y < rect.Height; y++)
                {
                    if (x < borderLength || y < borderLength)
                        DrawPixel(x + rect.X, y + rect.Y, color);
                    if (x >= rect.Width - borderLength || y >= rect.Height - borderLength)
                        DrawPixel(x + rect.X, y + rect.Y, color);
                }
            }
        }
    }
}
