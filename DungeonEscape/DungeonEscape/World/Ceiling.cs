using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonEscape
{
    class Ceiling
    {
        int width, height;

        RasterizerState rs;
        RasterizerState oldRs;

        public Ceiling(int width, int height)
        {
            this.width = width;
            this.height = height;

            rs = new RasterizerState();
            oldRs = new RasterizerState();

            rs.CullMode = CullMode.CullClockwiseFace;
            oldRs.CullMode = CullMode.CullCounterClockwiseFace;
        }

        public void Render()
        {
            Basic.gDevice.RasterizerState = rs;

            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    //GameScreen.effect.Texture = Textures.ceiling;
                    //GameScreen.effect.TextureEnabled = true;
                    GameScreen.mainEffect.Parameters["tex"].SetValue(Textures.ceiling);
                    GameScreen.mainEffect.Parameters["ambient"].SetValue(Level.MapColors.ceilingColor.ToVector4());
                    Model.floorModel.Draw(Matrix.CreateTranslation(x, 1, z));
                }
            }

            Basic.gDevice.RasterizerState = oldRs;
        }
    }
}
