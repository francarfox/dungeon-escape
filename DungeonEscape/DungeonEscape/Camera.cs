using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace DungeonEscape
{
    class Camera
    {
        public Matrix view, projection;

        public Vector3 position;
        public float speed = 0.04f;
        public float rotationSpeed = 0.004f;

        public Ray ray = new Ray();

        float yaw, pitch;

        int oldX, oldY;

        float tempF = 0;
        private bool movedLastFrame = false;

        public Camera()
        {
            position = new Vector3(0, 0, 5);

            view = Matrix.CreateLookAt(position, Vector3.Zero, Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f), Basic.gDevice.Viewport.AspectRatio, 0.01f, 1000.0f);

            ResetCursor();
        }

        public void Update()
        {
            movedLastFrame = false;
            //tempF += 0.25f;

            ray = CreateRay();

            KeyboardState kBoard = Keyboard.GetState();

            if (kBoard.IsKeyDown(Keys.W))
            {
                Vector3 v = new Vector3(0, 0, -1) * speed;
                Move(v);
            }
            if (kBoard.IsKeyDown(Keys.S))
            {
                Vector3 v = new Vector3(0, 0, 1) * speed;
                Move(v);
            }
            if (kBoard.IsKeyDown(Keys.A))
            {
                Vector3 v = new Vector3(-1, 0, 0) * speed;
                Move(v);
            }
            if (kBoard.IsKeyDown(Keys.D))
            {
                Vector3 v = new Vector3(1, 0, 0) * speed;
                Move(v);
            }

            if (movedLastFrame)
            {
                position.Y += (float)Math.Sin(tempF) * 0.0025f;
                tempF += 0.25f;
            }

            MouseState mState = Mouse.GetState();

            int dx = mState.X - oldX;
            int dy = mState.Y - oldY;
            yaw -= rotationSpeed * dx;
            pitch -= rotationSpeed * dy;

            pitch = MathHelper.Clamp(pitch, -1.5f, 1.5f);

            UpdateMatrices();
            ResetCursor();
        }

        private void UpdateMatrices()
        {
            Matrix rotation = Matrix.CreateRotationX(pitch) * Matrix.CreateRotationY(yaw);

            Vector3 transformed = Vector3.Transform(new Vector3(0, 0, -1), rotation);
            Vector3 lookAt = position + transformed;

            view = Matrix.CreateLookAt(position, lookAt, Vector3.Up);
        }

        private void ResetCursor()
        {
            if (Basic.game.IsActive)
            {
                Mouse.SetPosition(Basic.windowSize.Width / 2, Basic.windowSize.Height / 2);
                oldX = Basic.windowSize.Width / 2;
                oldY = Basic.windowSize.Height / 2;
            }
        }

        private void Move(Vector3 v)
        {
            movedLastFrame = true;

            Vector3 forward = Vector3.Transform(v, Matrix.CreateRotationY(yaw));

            if (!Contains(new Vector3(position.X + forward.X, 0, position.Z)))
                position.X += forward.X;
            if (!Contains(new Vector3(position.X, 0, position.Z + forward.Z)))
                position.Z += forward.Z;
        }

        private bool Contains(Vector3 v)
        {
            bool collided = false;
            foreach (Entity e in GameScreen.level.entities)
            {
                if (e.collision && e.box.Contains(v) == ContainmentType.Contains)
                {
                    collided = true;
                    break;
                }
            }

            return collided;
        }

        public Ray CreateRay()
        {
            int centerX = Basic.windowSize.Width / 2;
            int centerY = Basic.windowSize.Height / 2;

            Vector3 nearSource = new Vector3(centerX, centerY, 0);
            Vector3 farSource = new Vector3(centerX, centerY, 1);

            Vector3 nearPoint = Basic.gDevice.Viewport.Unproject(nearSource, projection, view, Matrix.Identity);
            Vector3 farPoint = Basic.gDevice.Viewport.Unproject(farSource, projection, view, Matrix.Identity);

            Vector3 direction = farPoint - nearPoint;
            direction.Normalize();

            return new Ray(nearPoint, direction);
        }
    }
}
