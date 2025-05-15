using System;
using System.Collections.Generic;

namespace QuizMaker
{
    public static class UI
    {
        private const int ANSWER_OPTIONS = 4;
        private const int NUMBER_OF_QUESTIONS_TO_ENTER = 3;
        private const int DISPLAY_INDEX_OFFSET = 1;
        private const int MIN_CHOICE = 1;

        private static readonly Random random = new Random();      // Random instance for  questions - only need one for the entire application


        public static int TakeQuiz(List<Questions> questions)        // Take the quiz - displays questions, gets user answers, and returns final score 
        {
            int score = 0;
            var pickAQuestions = questions.OrderBy(q => random.Next()).ToList(); // Shuffle questions randomly

            foreach (var question in pickAQuestions)
            {
                DisplayQuestion(question);
                int userAnswer = GetUserAnswer(question.Choices.Count); // Get validated user answer

                if (userAnswer == question.correctAnswer)
                {
                    score++;
                    DisplayCorrectAnswerFeedback();
                }
                else
                {
                    DisplayIncorrectAnswerFeedback(question.Choices[question.correctAnswer]);
                }
            }

            return score;
        }

        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("\nThis is a Quiz Maker Game!");
        }

        public static string DisplayMainMenuAndGetChoice()         // Display main menu options and get user selection 
        {
            Console.Clear();
            Console.WriteLine("Welcome to Quiz Maker!");
            Console.WriteLine("1. Create new quiz");
            Console.WriteLine("2. Take a quiz");
            Console.WriteLine("3. Exit");
            Console.Write("Select an option: ");

            return Console.ReadLine(); // Get user's menu choice
        }

        public static List<Questions> CreateQuestions()
        {
            List<Questions> questions = new List<Questions>(); // List to hold all questions entered by the user

            for (int i = 0; i < NUMBER_OF_QUESTIONS_TO_ENTER; i++)
            {
                string questionText = GetQuestionText(i);   // Get question text from user
                List<string> choices = CreateAnswers();    // Get answer choices from user
                int correctAnswerIndex = SelectAnswer(choices); // Get correct answer index

                questions.Add(new Questions
                {
                    questionEntry = questionText,
                    Choices = choices,
                    correctAnswer = correctAnswerIndex
                });
            }

            Console.WriteLine($"\n{NUMBER_OF_QUESTIONS_TO_ENTER} questions created!");
            return questions;
        }
        private static string GetQuestionText(int questionNumber)
        {
            Console.Write($"\nEnter question {questionNumber + DISPLAY_INDEX_OFFSET}: ");
            return Console.ReadLine(); // get question from the user
        }
        private static List<string> CreateAnswers()
        {
            List<string> choices = new List<string>();

            for (int j = 0; j < ANSWER_OPTIONS; j++)
            {
                Console.Write($"Choice {j + DISPLAY_INDEX_OFFSET}: ");
                string choice = Console.ReadLine(); // get answer choices
                choices.Add(choice);
            }

            Console.WriteLine("\nPlease review the choices:");
            for (int j = 0; j < choices.Count; j++)
            {
                Console.WriteLine($"{j + DISPLAY_INDEX_OFFSET}. {choices[j]}"); // Display all choices with numbers
            }

            return choices;
        }
        private static int SelectAnswer(List<string> choices)
        {
            Console.Write($"Enter the number of the correct choice ({MIN_CHOICE}-{ANSWER_OPTIONS}): ");
            string correctInput = Console.ReadLine();
            int correctIndex;

            while (!int.TryParse(correctInput, out correctIndex) ||
                   correctIndex < MIN_CHOICE || correctIndex > ANSWER_OPTIONS)
            {
                Console.Write($"Please enter a valid number between {MIN_CHOICE} and {ANSWER_OPTIONS}: ");
                correctInput = Console.ReadLine();
            }

            return correctIndex - DISPLAY_INDEX_OFFSET;   // Convert to zero-based index
        }

        public static void DisplayQuizSavedMessage()
        {
            Console.WriteLine("\nQuiz saved successfully!");
        }

        public static void DisplayNoQuizFoundMessage()
        {
            Console.WriteLine("\nNo saved quiz found. Please create a quiz first.");
        }

        public static void DisplayExitMessage()
        {
            Console.WriteLine("\nThank you for using Quiz Maker. Goodbye!");
        }

        public static void DisplayInvalidChoiceMessage()
        {
            Console.WriteLine("\nInvalid choice. Please enter 1, 2, or 3.");
        }

        public static void DisplayFinalScore(int score, int totalQuestions)
        {
            Console.WriteLine($"\nQuiz complete! Your score: {score}/{totalQuestions}");
        }
        public static void DisplayQuestion(Questions question)
        {
            Console.WriteLine($"\nQuestion: {question.questionEntry}");

            for (int i = 0; i < question.Choices.Count; i++)
            {
                Console.WriteLine($"{i + DISPLAY_INDEX_OFFSET}. {question.Choices[i]}");
            }
        }
        public static int GetUserAnswer(int answerChoice) // Get and validate user's answers
        {
            Console.Write($"Enter your answer (1-{answerChoice}): ");
            string userInput = Console.ReadLine();
            int userAnswer;

            while (!int.TryParse(userInput, out userAnswer) || userAnswer < MIN_CHOICE || userAnswer > answerChoice)
            {
                Console.Write($"Please enter a number between 1 and {answerChoice}: ");
                userInput = Console.ReadLine();
            }

            return userAnswer - DISPLAY_INDEX_OFFSET; // Convert to zero-based index
        }
        public static void DisplayCorrectAnswerFeedback()
        {
            Console.WriteLine("Correct!\n");
        }
        public static void DisplayIncorrectAnswerFeedback(string correctAnswer)
        {
            Console.WriteLine($"Incorrect. The correct answer was: {correctAnswer}\n");
        }
    }
}