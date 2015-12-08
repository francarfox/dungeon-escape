using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DungeonEscape
{
    class BlockModel : Model
    {
        public BlockModel()
        {
            //front side
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(0, 1)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(0, 0)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(1, 1)));

            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(1, 1)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(0, 0)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(0, 0, 1), new Vector2(1, 0)));

            //right side
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, 0.5f), new Vector3(1, 0, 0), new Vector2(0, 1)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1, 0, 0), new Vector2(0, 0)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, -0.5f), new Vector3(1, 0, 0), new Vector2(1, 1)));

            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, -0.5f), new Vector3(1, 0, 0), new Vector2(1, 1)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, 0.5f), new Vector3(1, 0, 0), new Vector2(0, 0)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, -0.5f), new Vector3(1, 0, 0), new Vector2(1, 0)));

            //left side
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(-1, 0, 0), new Vector2(0, 0)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, 0.5f), new Vector3(-1, 0, 0), new Vector2(0, 1)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(-1, 0, 0), new Vector2(1, 1)));

            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(-1, 0, 0), new Vector2(1, 1)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(-1, 0, 0), new Vector2(1, 0)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, 0.5f), new Vector3(-1, 0, 0), new Vector2(0, 0)));

            //back side
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(0, 0)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(0, 1)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(1, 1)));

            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(1, 1)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(1, 0)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(0, 0, -1), new Vector2(0, 0)));

            SetUp();
        }
    }
}
