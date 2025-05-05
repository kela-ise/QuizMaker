namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string questions = File.ReadAllText(Constants.QUIZ_QUESTIONS);
            UI.DisplayWelcomeMessage();
            UI.DisplayQuestions(questions);
            Console.ReadKey();
        }
    }
}
