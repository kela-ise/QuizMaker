using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UI.DisplayWelcomeMessage();

            while (true)
            {
                string choice = UI.DisplayMainMenuAndGetChoice();

                switch (choice)
                {
                    case "1":
                        List<Questions> questions = UI.CreateQuestions();
                        Logic.SaveQuestions(questions);
                        UI.DisplayQuizSavedMessage();
                        break;

                    case "2":
                        List<Questions> loadedQuestions = Logic.LoadQuestions();
                        if (loadedQuestions.Count == 0)
                        {
                            UI.DisplayNoQuizFoundMessage();
                        }
                        else
                        {
                            int score = Logic.TakeQuiz(loadedQuestions);
                            UI.DisplayFinalScore(score, loadedQuestions.Count);
                        }
                        break;

                    case "3":
                        UI.DisplayExitMessage();
                        return;

                    default:
                        UI.DisplayInvalidChoiceMessage();
                        break;
                }
            }
        }
    }
}