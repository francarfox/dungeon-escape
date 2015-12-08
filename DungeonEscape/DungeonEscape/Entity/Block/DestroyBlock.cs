using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;

namespace DungeonEscape
{
    class DestroyBlock : Entity
    {
        public DestroyBlock(float x, float y, float z)
            : base(x, y, z)
        {
        }

        public override void Update()
        {
            Nullable<float> result = box.Intersects(GameScreen.camera.ray);

            if (result.HasValue && result.Value < 2.0f && Mouse.GetState().LeftButton == ButtonState.Pressed && GameScreen.oldState.LeftButton == ButtonState.Released && GameScreen.player.itemBar.selectedItem == Textures.pickAxe)
            {
                GameScreen.player.itemBar.RemoveSelectedItem();
                Sounds.destroyBlock.Play();
                GameScreen.level.hasToRemove.Add(this);
            }

            base.Update();
        }

        public override void Render()
        {
            //GameScreen.effect.Texture = Textures.destroyableBlock;
            //GameScreen.effect.TextureEnabled = true;
            GameScreen.mainEffect.Parameters["tex"].SetValue(Textures.destroyableBlock);
            GameScreen.mainEffect.Parameters["ambient"].SetValue(Level.MapColors.destroyColor.ToVector4());
            Draw(Model.blockModel);
        }
    }
}
