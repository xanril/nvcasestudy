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
        private string inputPrompt;

        abstract public void Display();
        public abstract void ReadInput(string userInput);

        public virtual void ShowError()
        {
            if (string.IsNullOrEmpty(errorMessage))
                return;

            Console.WriteLine(errorMessage);
            errorMessage = string.Empty;
        }

        public virtual void ShowInputPrompt()
        {
            Console.Write(this.inputPrompt);
        }

        public void SetErrorMessage(string errorMessage)
        {
            this.errorMessage = errorMessage;
        }

        public void SetInputPrompt(string message)
        {
            this.inputPrompt = message;
        }

        public void ShowInputFeedback(string feedbackMessage)
        {
            Console.WriteLine(feedbackMessage);
        }
    }
}
