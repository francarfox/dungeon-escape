using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DungeonEscape
{
    class Floor
    {
        int width, height;

        public Floor(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public void Render()
        {
            for (int x = 0; x < width; x++)
            {
                for (int z = 0; z < height; z++)
                {
                    //GameScreen.effect.Texture = Textures.floor;
                    //GameScreen.effect.TextureEnabled = true;
                    GameScreen.mainEffect.Parameters["tex"].SetValue(Textures.floor);
                    GameScreen.mainEffect.Parameters["ambient"].SetValue(Level.MapColors.floorColor.ToVector4());
                    Model.floorModel.Draw(Matrix.CreateTranslation(x, 0, z));
                }
            }
        }
    }
}
