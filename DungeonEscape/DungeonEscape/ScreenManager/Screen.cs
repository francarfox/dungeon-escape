using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonEscape
{
    class Screen
    {
        public virtual void Init() { }
        public virtual void Update() { }
        public virtual void Render() { }

        public void ShowMouse()
        {
            Basic.game.IsMouseVisible = true;
        }

        public void HideMouse()
        {
            Basic.game.IsMouseVisible = false;
        }
    }
}
