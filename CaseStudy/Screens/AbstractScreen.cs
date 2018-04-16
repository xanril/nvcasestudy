using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Screens
{
    abstract class AbstractScreen
    {
        abstract public void Display();
        abstract public void ShowInputPrompt();
        abstract public void ProcessInput(string userInput);
    }
}
