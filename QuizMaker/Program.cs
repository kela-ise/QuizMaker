using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
         //   string questions = File.ReadAllText(Constants.QUIZ_QUESTIONS);
            UI.DisplayWelcomeMessage();
            UI.CreateQuestions();
            Console.ReadKey();
        }
    }
}
