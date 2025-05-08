using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI.DisplayWelcomeMessage();

            List<Questions> questions = UI.CreateQuestions();   // Get questions from user input via UI

            Logic.SaveQuestions(questions); // Pass the questions to Logic for saving

            Console.ReadKey();
        }
    }
}