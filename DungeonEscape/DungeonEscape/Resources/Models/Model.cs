using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DungeonEscape
{
    class Model
    {
        public  List<VertexPositionNormalTexture> vertexData = new List<VertexPositionNormalTexture>();
        public VertexBuffer vertexBuffer;

        public void SetUp()
        {
            vertexBuffer = new VertexBuffer(Basic.gDevice, typeof(VertexPositionNormalTexture), vertexData.Count, BufferUsage.WriteOnly);
            vertexBuffer.SetData(vertexData.ToArray());
        }

        public void Draw(Matrix world)
        {
            //GameScreen.effect.View = GameScreen.camera.view;
            //GameScreen.effect.Projection = GameScreen.camera.projection;
            //GameScreen.effect.EnableDefaultLighting();
            //GameScreen.effect.World = world;

            //GameScreen.effect.FogEnabled = true;    //niebla
            //GameScreen.effect.FogColor = Color.Black.ToVector3();
            //GameScreen.effect.FogStart = 3.0f;
            //GameScreen.effect.FogEnd = 7.0f;

            //GameScreen.effect.CurrentTechnique.Passes[0].Apply();

            GameScreen.mainEffect.Parameters["world"].SetValue(world);
            GameScreen.mainEffect.Parameters["view"].SetValue(GameScreen.camera.view);
            GameScreen.mainEffect.Parameters["projection"].SetValue(GameScreen.camera.projection);

            GameScreen.mainEffect.CurrentTechnique.Passes[0].Apply();

            Basic.gDevice.SetVertexBuffer(vertexBuffer);
            Basic.gDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, vertexBuffer.VertexCount / 3);
        }

        public static Model floorModel = new FloorFace();
        public static Model blockModel = new BlockModel();
        public static Model spriteModel = new SpriteFace();
    }
}
