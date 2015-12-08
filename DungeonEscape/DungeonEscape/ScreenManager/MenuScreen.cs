using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DungeonEscape
{
    class MenuScreen : Screen
    {
        List<Button> buttons = new List<Button>();

        public MenuScreen()
        {
            ShowMouse();

            buttons.Add(new Button(Basic.windowSize.Width / 2 - 100, 50, 200, 50, "New Game", NewGame));
            buttons.Add(new Button(Basic.windowSize.Width / 2 - 100, 110, 200, 50, "Load Game", LoadGame));
            buttons.Add(new Button(Basic.windowSize.Width / 2 - 100, 170, 200, 50, "Show Tutorial", ShowTutorial));
            buttons.Add(new Button(Basic.windowSize.Width / 2 - 100, 230, 200, 50, "Options", ShowOptions));
            buttons.Add(new Button(Basic.windowSize.Width / 2 - 100, 290, 200, 50, "Exit", Quit));
        }

        public override void Update()
        {
            foreach (Button button in buttons)
            {
                button.Update();
            }

            base.Update();
        }

        public override void Render()
        {
            foreach (Button button in buttons)
            {
                button.Render();
            }

            base.Render();
        }

        #region ClickFunctions

        public void NewGame()
        {
            Basic.SetScreen(new GameScreen());
        }

        public void LoadGame()
        {
            Basic.SetScreen(new GameScreen());
        }

        public void ShowTutorial()
        {
        }

        public void ShowOptions()
        {
        }

        public void Quit()
        {
            Basic.game.Exit();
        }

        #endregion
    }
}
