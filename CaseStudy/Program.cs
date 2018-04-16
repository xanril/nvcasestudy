using CaseStudy.Models;
using CaseStudy.Screens;
using System;

namespace CaseStudy
{
    class Program
    {
        static void Main(string[] args)
        {
            DataManager.GetInstance().LoadData();

            Console.WriteLine("Welcome to Airline X Flight Management System!");
            Console.WriteLine("");

            ScreenManager.GetInstance().Initialize();
            ScreenManager.GetInstance().ShowScreen();

            Console.WriteLine("");
            Console.WriteLine("- - - - - -");
            Console.WriteLine("Program Exited.");
            Console.ReadKey();
        }
    }
}
