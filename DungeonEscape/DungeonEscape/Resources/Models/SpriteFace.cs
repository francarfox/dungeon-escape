using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DungeonEscape
{
    class SpriteFace : Model
    {
        public SpriteFace()
        {
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, 0.0f), Vector3.Backward, new Vector2(0, 1)));
            vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, 0.5f, 0.0f), Vector3.Backward, new Vector2(0, 0))); vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, 0.0f), Vector3.Backward, new Vector2(1, 0)));

            vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, 0.5f, 0.0f), Vector3.Backward, new Vector2(1, 0))); vertexData.Add(new VertexPositionNormalTexture(new Vector3(0.5f, -0.5f, 0.0f), Vector3.Backward, new Vector2(1, 1))); vertexData.Add(new VertexPositionNormalTexture(new Vector3(-0.5f, -0.5f, 0.0f), Vector3.Backward, new Vector2(0, 1)));

            SetUp();
        }
    }
}
