using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace DungeonEscape
{
    class Level
    {
        public Floor floor;
        public Ceiling ceiling;

        private int mapWidth, mapHeight;
        public int level;

        private Texture2D mapTexture;
        public Color[,] colorData;

        public List<Entity> entities = new List<Entity>();
        public List<Entity> hasToRemove = new List<Entity>();

        public LevelManager levelManager;

        public int spawnX, spawnZ;

        public struct MapColors
        {
            public static Color wallColor;
            public static Color destroyColor;
            public static Color doorColor;
            public static Color gridColor;

            public static Color floorColor;
            public static Color ceilingColor;
            public static bool hasCeiling;
        };

        public Level(int level)
        {
            mapTexture = Basic.content.Load<Texture2D>("Levels\\Level" + level);

            mapWidth = mapTexture.Width;
            mapHeight = mapTexture.Height;

            levelManager = new LevelManager(level);

            colorData = TextureToColor(mapTexture);
            this.level = level;

            Sounds.changeLevel.Play();

            #region MapColors

            MapColors.wallColor = levelManager.GetWallColor();
            MapColors.destroyColor = levelManager.GetDestroyColor();
            MapColors.doorColor = levelManager.GetDoorColor();
            MapColors.gridColor = levelManager.GetGridColor();

            MapColors.floorColor = levelManager.GetFloorColor();
            MapColors.ceilingColor = levelManager.GetCeilingColor();
            MapColors.hasCeiling = levelManager.HasCeiling();

            #endregion

            floor = new Floor(mapWidth, mapHeight);
            if(MapColors.hasCeiling)
                ceiling = new Ceiling(mapWidth, mapHeight);

            SetUpMap();
        }

        public void Update()
        {
            hasToRemove = new List<Entity>();

            entities.Sort();

            for (int i = 0; i < entities.Count; i++)
            {
                try
                {
                    entities[i].Update();
                }
                catch { }
            }

            if (hasToRemove.Count > 0)
            {
                float minDistance = hasToRemove[0].cameraDistance;
                Entity nearestEntity = hasToRemove[0];

                for (int i = 1; i < hasToRemove.Count; i++)
                {
                    if (hasToRemove[i].cameraDistance < minDistance)
                    {
                        minDistance = hasToRemove[i].cameraDistance;
                        nearestEntity = hasToRemove[i];
                    }
                }

                entities.Remove(nearestEntity); //solo remueve el mas cercano
            }
        }

        public void Render()
        {
            floor.Render();
            if(MapColors.hasCeiling)
                ceiling.Render();

            for (int i = 0; i < entities.Count; i++)
            {
                try
                {
                    entities[i].Render();
                }
                catch { }
            }

            Basic.spriteBatch.DrawString(Basic.mainFont, levelManager.GetName(), new Vector2(5, 5), Color.White);
        }

        private void SetUpMap()
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int z = 0; z < mapHeight; z++)
                {
                    if (colorData[x, z] == Color.White)
                        entities.Add(new WallBlock(x, 0, z));
                    if (colorData[x, z] == new Color(0, 255, 0))
                        entities.Add(new DestroyBlock(x, 0, z));
                    if (colorData[x, z] == new Color(0, 0, 255))
                        entities.Add(new GridBlock(x, 0, z));
                    if (colorData[x, z] == new Color(0, 128, 0))
                        entities.Add(new DoorBlock(x, 0, z));

                    if (colorData[x, z] == new Color(255, 255, 0))
                        entities.Add(new Key(x, 0, z));
                    if (colorData[x, z] == new Color(128, 0, 0))
                        entities.Add(new Pliers(x, 0, z));
                    if (colorData[x, z] == new Color(0, 255, 255))
                        entities.Add(new PickAxe(x, 0, z));

                    if (colorData[x, z] == new Color(0, 0, 128))
                        entities.Add(new LevelUp(x, 0, z));
                    if (colorData[x, z] == new Color(0, 128, 128))
                        entities.Add(new LevelDown(x, 0, z));

                    if (colorData[x, z] == new Color(255, 0, 0))
                    {
                        GameScreen.camera.position = new Vector3(x, 0, z);
                        spawnX = x;
                        spawnZ = z;
                    }
                }
            }
        }

        private Color[,] TextureToColor(Texture2D tex)
        {
            Color[] col2D = new Color[tex.Width * tex.Height];
            tex.GetData(col2D);

            Color[,] data = new Color[tex.Width, tex.Height];

            for (int i = 0; i < tex.Width; i++)
            {
                for (int j = 0; j < tex.Height; j++)
                {
                    data[i, j] = col2D[i + j * tex.Width];
                }
            }

            return data;
        }

        public Entity GetEntity(float x, float z)
        {
            foreach (Entity e in entities)
            {
                if (e.position.X == x && e.position.Z == z)
                    return e;
            }

            return null;
        }
    }
}
