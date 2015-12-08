using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace DungeonEscape
{
    class Sounds
    {
        public static SoundEffectInstance changeLevel;
        public static SoundEffectInstance collect;
        public static SoundEffectInstance destroyBlock;
        public static SoundEffectInstance destroyGrid;
        public static SoundEffectInstance openDoor;

        public static void LoadSounds()
        {
            changeLevel = LoadSound("changeLevel");
            collect = LoadSound("collect");
            destroyBlock = LoadSound("destroyBlock");
            destroyGrid = LoadSound("destroyGrid");
            openDoor = LoadSound("openDoor");
        }

        private static SoundEffectInstance LoadSound(String path)
        {
            return Basic.content.Load<SoundEffect>("Sounds\\" + path).CreateInstance();
        }
    }
}
