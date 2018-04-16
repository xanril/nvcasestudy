using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Screens
{
    interface IScreen
    {
        void Display();
        void ShowInputPrompt();
        void ProcessInput(string userInput);
    }
}
