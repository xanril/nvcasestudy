using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Abstracts
{
    abstract public class AbstractView
    {
        private string errorMessage;

        abstract public void Display();
        public abstract void ReadInput(string userInput);

        public virtual void ShowError()
        {
            Console.WriteLine(errorMessage);
            errorMessage = string.Empty;
        }

        public virtual void ShowInputPrompt()
        {
            if (string.IsNullOrEmpty(errorMessage) == false)
                ShowError();
        }

        

        public void SetErrorMessage(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }

        public void ShowInputFeedback(string feedbackMessage)
        {
            Console.WriteLine(feedbackMessage);
        }
    }
}
