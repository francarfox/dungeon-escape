using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace DungeonEscape
{
    class LevelManager
    {
        public int level;

        public LevelManager(int level)
        {
            this.level = level;
        }

        #region Entities

        public Color GetWallColor()
        {
            if (level == 1)
                return new Color(255, 0, 0);
            else
                return Color.White;
        }

        public Color GetDestroyColor()
        {
            if (level == 1)
                return new Color(0, 255, 255);
            else
                return Color.White;
        }

        public Color GetDoorColor()
        {
            if (level == 1)
                return new Color(0, 255, 0);
            else
                return Color.White;
        }

        public Color GetGridColor()
        {
            if (level == 1)
                return new Color(0, 0, 255);
            else
                return Color.White;
        }

        #endregion

        #region Environment

        public Color GetFloorColor()
        {
            if (level == 1)
                return new Color(255, 0, 255);
            else
                return Color.White;
        }

        public Color GetCeilingColor()
        {
            if (level == 1)
                return new Color(255, 0, 255);
            else
                return Color.White;
        }

        public bool HasCeiling()
        {
            if (level == 1)
                return true;
            else
                return false;
        }

        #endregion

        #region Level

        public String GetName()
        {
            if (level == 1)
                return "Prison";
            else
                return "Default";
        }

        #endregion
    }
}
