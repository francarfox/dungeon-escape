using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonEscape
{
    class GridBlock : Entity
    {
        RasterizerState rs = new RasterizerState();
        RasterizerState before = new RasterizerState();

        public bool destroyed = false;

        public GridBlock(float x, float y, float z)
            : base(x, y, z)
        {
            rs.CullMode = CullMode.None;
            before.CullMode = CullMode.CullCounterClockwiseFace;

            drawBoundingBox = true;
        }

        public override void Update()
        {
            if (GameScreen.level.GetEntity(position.X, position.Z + 1) is WallBlock && GameScreen.level.GetEntity(position.X, position.Z - 1) is WallBlock)
                rotation.Y = MathHelper.PiOver2;

            if (destroyed)
                collision = false;

            Nullable<float> result = box.Intersects(GameScreen.camera.ray);

            if (result.HasValue && result.Value < 2.0f && Mouse.GetState().LeftButton == ButtonState.Pressed && !destroyed && GameScreen.player.itemBar.selectedItem == Textures.pliers)
            {
                GameScreen.player.itemBar.RemoveSelectedItem();
                Sounds.collect.Play();
                destroyed = true;
            }

            if (rotation.Y == 0)    //para pisar mas cerca de la reja
                boundingBoxScale.Z = 0.6f;
            else
                boundingBoxScale.X = 0.6f;

            base.Update();
        }

        public override void Render()
        {
            if(!destroyed)
                //GameScreen.effect.Texture = Textures.grid;
                GameScreen.mainEffect.Parameters["tex"].SetValue(Textures.grid);
            else
                //GameScreen.effect.Texture = Textures.gridDestroyed;
                GameScreen.mainEffect.Parameters["tex"].SetValue(Textures.gridDestroyed);

            GameScreen.mainEffect.Parameters["ambient"].SetValue(Level.MapColors.gridColor.ToVector4());
            //GameScreen.effect.TextureEnabled = true;

            Basic.gDevice.RasterizerState = rs;

            Draw(Model.spriteModel);

            Basic.gDevice.RasterizerState = before;

            base.Render();
        }
    }
}
