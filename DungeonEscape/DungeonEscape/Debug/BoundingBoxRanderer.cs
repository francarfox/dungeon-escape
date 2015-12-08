using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DungeonEscape
{
    class BoundingBoxRanderer
    {
        public static BasicEffect effect;
        public static VertexPositionColor[] vertex = new VertexPositionColor[8];
        public static Int16[] indices = new Int16[]
        {
            0, 1,
            1, 2,
            2, 3,
            3, 0,
            0, 4,
            1, 5,
            2, 6,
            3, 7,
            4, 5,
            5, 6,
            6, 7,
            7, 4
        };

        public static void Render(BoundingBox box, GraphicsDevice device, Matrix view, Matrix projection, Color color)
        {
            if (effect == null)
            {
                effect = new BasicEffect(device);
                effect.VertexColorEnabled = true;
                effect.LightingEnabled = false;
            }

            Vector3[] corners = box.GetCorners();

            for (int i = 0; i < 8; i++)
            {
                vertex[i].Position = corners[i];
                vertex[i].Color = color;
            }

            effect.View = view;
            effect.Projection = projection;

            foreach (EffectPass pass in effect.CurrentTechnique.Passes)
            {
                pass.Apply();

                device.DrawUserIndexedPrimitives(PrimitiveType.LineList, vertex, 0, 8, indices, 0, indices.Length / 2);
            }
        }
    }
}
