using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DungeonEscape
{
    class Pliers : Entity
    {
        RasterizerState rs = new RasterizerState();
        RasterizerState before = new RasterizerState();

        float tempF = 0;

        public Pliers(float x, float y, float z)
            : base(x, y, z)
        {
            collision = false;
            drawBoundingBox = true;

            rs.CullMode = CullMode.None;
            before.CullMode = CullMode.CullCounterClockwiseFace;

            scale = new Vector3(0.4f, 0.4f, 1.0f);
            boundingBoxScale = new Vector3(0.4f);
        }

        public override void Update()
        {
            rotation.Y += 0.03f;
            tempF += 0.05f;

            position.Y = (float)Math.Sin(tempF) * 0.05f;

            if (box.Contains(GameScreen.camera.position) == ContainmentType.Contains)
            {
                if (GameScreen.player.itemBar.SetItem(Textures.pliers))
                {
                    Sounds.collect.Play();
                    Remove();
                }
            }

            base.Update();
        }

        public override void Render()
        {
            //GameScreen.effect.Texture = Textures.pliers;
            //GameScreen.effect.TextureEnabled = true;
            GameScreen.mainEffect.Parameters["tex"].SetValue(Textures.pliers);
            GameScreen.mainEffect.Parameters["ambient"].SetValue(Color.White.ToVector4());

            Basic.gDevice.RasterizerState = rs;

            Draw(Model.spriteModel);

            Basic.gDevice.RasterizerState = before;

            base.Render();
        }
    }
}
