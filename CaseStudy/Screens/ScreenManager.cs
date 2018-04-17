using System;
using System.Collections.Generic;

namespace CaseStudy.Screens
{
    class ScreenManager
    {
        private static ScreenManager instance;
        public static ScreenManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ScreenManager();
            }

            return instance;
        }

        private Stack<IScreen> screenStack;
        private IScreen activeScreen;

        private ScreenManager()
        {
            this.screenStack = new Stack<IScreen>();
        }

        public void Initialize()
        {
            MenuScreen screen = new MenuScreen();
            PushScreen(screen);
        }

        public void ShowScreen()
        {
            do
            {
                this.activeScreen.ShowInputPrompt();
                string userInput = Console.ReadLine();
                this.activeScreen.ProcessInput(userInput);

            } while (this.screenStack.Count != 0);
        }

        public void PopScreen()
        {
            this.screenStack.Pop();
            if (screenStack.Count > 0)
            {
                this.activeScreen = this.screenStack.Peek();
                this.activeScreen.Display();
            }
        }

        public void PopScreenUntilTargetType(Type ofType)
        {
            bool willStop = false;

            // only process types that is derived from IScreen
            if (typeof(IScreen).IsAssignableFrom(ofType) == false)
                return;

            do
            {
                if (screenStack.Count == 0)
                    willStop = true;
                else
                {
                    if (this.screenStack.Peek().GetType().Equals(ofType) == false)
                        this.screenStack.Pop();
                    else
                    {
                        willStop = true;
                        this.activeScreen = this.screenStack.Peek();
                        this.activeScreen.Display();
                    }
                }
            }
            while (willStop == false);
        }

        public void PushScreen(IScreen screen)
        {
            if (screen != null)
            {
                this.screenStack.Push(screen);
                this.activeScreen = screenStack.Peek();

                this.activeScreen.Display();
            }
        }
    }
}
