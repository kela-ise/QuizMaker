using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizMaker
{
   public static class UI
    {

        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("\n This is a Quiz Maker Game!");


        }
        public static void DisplayQuestions(string info)
        {
            Console.WriteLine(" \n You can create new questions or just take a quiz ");
            string questions = File.ReadAllText(Constants.QUIZ_QUESTIONS);
            Console.WriteLine("\n" + questions);


        }




    }
}
