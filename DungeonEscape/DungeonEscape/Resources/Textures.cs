using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonEscape
{
    class Textures
    {
        public static Texture2D wall;
        public static Texture2D destroyableBlock;

        public static Texture2D pickAxe;
        public static Texture2D pliers;
        public static Texture2D key;

        public static Texture2D floor;
        public static Texture2D ceiling;
        public static Texture2D grid;
        public static Texture2D gridDestroyed;
        public static Texture2D door;
        public static Texture2D levelUp;
        public static Texture2D levelDown;

        public static void LoadTextures()
        {
            wall = LoadTex("Blocks\\wall");
            destroyableBlock = LoadTex("Blocks\\destroyableBlock");

            pickAxe = LoadTex("Items\\pickAxe");
            pliers = LoadTex("Items\\pliers");
            key = LoadTex("Items\\key");

            floor = LoadTex("Sprites\\floor");
            ceiling = LoadTex("Sprites\\ceiling");
            grid = LoadTex("Sprites\\grid");
            gridDestroyed = LoadTex("Sprites\\gridDestroyed");
            door = LoadTex("Sprites\\door");
            levelUp = LoadTex("Sprites\\levelUp");
            levelDown = LoadTex("Sprites\\levelDown");
        }

        private static Texture2D LoadTex(String path)
        {
            return Basic.content.Load<Texture2D>("Textures\\" + path);
        }
    }
}
