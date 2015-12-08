using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonEscape
{
    class WallBlock : Entity
    {
        public WallBlock(float x, float y, float z)
            : base(x, y, z)
        {
            drawBoundingBox = true;
        }

        public override void Render()
        {
            //GameScreen.effect.Texture = Textures.wall;
            //GameScreen.effect.TextureEnabled = true;
            GameScreen.mainEffect.Parameters["tex"].SetValue(Textures.wall);
            GameScreen.mainEffect.Parameters["ambient"].SetValue(Level.MapColors.wallColor.ToVector4());
            Draw(Model.blockModel);
        }
    }
}
