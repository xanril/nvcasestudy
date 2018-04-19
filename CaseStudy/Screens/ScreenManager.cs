using CaseStudy.Abstracts;
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

        private Stack<AbstractView> viewStack;
        private AbstractView activeView;

        private ScreenManager()
        {
            this.viewStack = new Stack<AbstractView>();
            activeView = null;
        }

        public void Initialize()
        {
            MenuScreen start = new MenuScreen();
        }

        public void SetActiveView(AbstractView view)
        {
            this.viewStack.Clear();
            this.viewStack.Push(view);
            this.activeView = this.viewStack.Peek();
            this.activeView.Display();
        }

        public void ShowScreen()
        {
            do
            {
                this.activeView.ShowInputPrompt();
                string userInput = Console.ReadLine();
                this.activeView.ReadInput(userInput);

            } while (this.viewStack.Count != 0);
        }

        public void PopScreen()
        {
            //this.viewStack.Pop();
            //if (viewStack.Count > 0)
            //{
            //    this.activeView = this.viewStack.Peek();
            //    this.activeView.Display();
            //}
        }

        public void PopScreenUntilTargetType(Type ofType)
        {
            //bool willStop = false;

            //// only process types that is derived from IScreen
            //if (typeof(IScreen).IsAssignableFrom(ofType) == false)
            //    return;

            //do
            //{
            //    if (viewStack.Count == 0)
            //        willStop = true;
            //    else
            //    {
            //        if (this.viewStack.Peek().GetType().Equals(ofType) == false)
            //            this.viewStack.Pop();
            //        else
            //        {
            //            willStop = true;
            //            this.activeView = this.viewStack.Peek();
            //            this.activeView.Display();
            //        }
            //    }
            //}
            //while (willStop == false);
        }

        public void PushScreen(IScreen screen)
        {
            //if (screen != null)
            //{
            //    this.viewStack.Push(screen);
            //    this.activeView = viewStack.Peek();

            //    this.activeView.Display();
            //}
        }
    }
}
