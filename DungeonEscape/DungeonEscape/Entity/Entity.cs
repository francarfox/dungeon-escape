using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DungeonEscape
{
    class Entity : IComparable
    {
        public Vector3 position;
        public Vector3 rotation = new Vector3(0);
        public Vector3 scale = new Vector3(1);

        public bool drawBoundingBox = false;
        public bool collision = true;
        public Vector3 boundingBoxScale = new Vector3(1.4f);

        public float cameraDistance;

        public BoundingBox box = new BoundingBox(new Vector3(-0.5f), new Vector3(0.5f));

        public Matrix world;

        public Entity(float x, float y, float z)
        {
            position = new Vector3(x, y, z);
        }

        public virtual void Update()
        {
            world = Matrix.CreateScale(scale) * Matrix.CreateFromYawPitchRoll(rotation.Y, rotation.X, rotation.Z) * Matrix.CreateTranslation(position);
            box = new BoundingBox(Vector3.Transform(new Vector3(-0.5f), Matrix.CreateScale(boundingBoxScale) * Matrix.CreateTranslation(position)), Vector3.Transform(new Vector3(0.5f), Matrix.CreateScale(boundingBoxScale) * Matrix.CreateTranslation(position)));

            cameraDistance = Vector3.Distance(position, GameScreen.camera.position);
        }

        public void Draw(Model model)
        {
            model.Draw(world);

            //if (drawBoundingBox)
            //    BoundingBoxRanderer.Render(box, Basic.gDevice, GameScreen.camera.view, GameScreen.camera.projection, Color.Red);  //cuadro rojo de seleccion
        }

        public virtual void Render() { }

        public void Remove()
        {
            GameScreen.level.entities.Remove(this);
        }

        public int CompareTo(object obj)
        {
            Entity e = (Entity)obj;

            return (int)((e.cameraDistance - this.cameraDistance) * 1000);
        }
    }
}
