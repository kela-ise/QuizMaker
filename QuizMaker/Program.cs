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
                    case Constants.CREATE_QUIZ_MODE:
                        List<Questions> questions = UI.CreateQuestions();
                        Logic.SaveQuestions(questions);
                        UI.DisplayQuizSavedMessage();
                        break;

                    case Constants.TAKE_QUIZ_MODE:
                        List<Questions> loadedQuestions = Logic.LoadQuestions();
                        if (loadedQuestions.Count == 0)
                        {
                            UI.DisplayNoQuizFoundMessage();
                        }
                        else
                        {
                            int score = UI.TakeQuiz(loadedQuestions);
                            UI.DisplayFinalScore(score, loadedQuestions.Count);
                        }
                        break;

                    case Constants.EXIT_MODE:
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