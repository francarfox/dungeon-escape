using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonEscape
{
    class DoorBlock : Entity
    {
        RasterizerState rs = new RasterizerState();
        RasterizerState before = new RasterizerState();

        bool hasToMove = false;
        float tempI = 0;

        public DoorBlock(float x, float y, float z)
            : base(x, y, z)
        {
            rs.CullMode = CullMode.None;
            before.CullMode = CullMode.CullCounterClockwiseFace;
        }

        public override void Update()
        {
            if (GameScreen.level.GetEntity(position.X, position.Z + 1) is WallBlock && GameScreen.level.GetEntity(position.X, position.Z - 1) is WallBlock)
                rotation.Y = MathHelper.PiOver2;

            Nullable<float> result = box.Intersects(GameScreen.camera.ray);

            if (result.HasValue && result.Value < 2.0f && !hasToMove && Mouse.GetState().LeftButton == ButtonState.Pressed && !hasToMove && GameScreen.player.itemBar.selectedItem == Textures.key)
            {
                GameScreen.player.itemBar.RemoveSelectedItem();
                Sounds.openDoor.Play();
                hasToMove = true;
            }

            if (hasToMove && rotation.Y == 0)
            {
                tempI += 0.03f;
                position.X -= 0.03f;

                if (tempI > 1)
                    Remove();
            }

            if (hasToMove && rotation.Y != 0)
            {
                tempI += 0.03f;
                position.Z += 0.03f;

                if (tempI > 1)
                    Remove();
            }

            if (rotation.Y == 0)
                boundingBoxScale.Z = 0.6f;
            else
                boundingBoxScale.X = 0.6f;

            base.Update();
        }

        public override void Render()
        {
            //GameScreen.effect.Texture = Textures.door;
            //GameScreen.effect.TextureEnabled = true;
            GameScreen.mainEffect.Parameters["tex"].SetValue(Textures.door);
            GameScreen.mainEffect.Parameters["ambient"].SetValue(Level.MapColors.doorColor.ToVector4());

            Basic.gDevice.RasterizerState = rs;

            Draw(Model.spriteModel);

            Basic.gDevice.RasterizerState = before;

            base.Render();
        }
    }
}
