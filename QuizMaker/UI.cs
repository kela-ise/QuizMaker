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

        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("\nThis is a Quiz Maker Game!");
            Console.WriteLine(" \nCreate new questions ");
        }

        public static List<Questions> CreateQuestions()
        {
            List<Questions> questions = new List<Questions>(); // List to hold all questions entered by the user

            for (int i = 0; i < NUMBER_OF_QUESTIONS_TO_ENTER; i++)
            {
                string questionText = GetQuestionText(i);   // Get question text

                List<string> choices = CreateAnswers();      // Get answer choices

                int correctAnswerIndex = SelectAnswer(choices);    // Get correct answer

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
                Console.WriteLine($"{j + DISPLAY_INDEX_OFFSET}. {choices[j]}");
            }

            return choices;
        }

        private static int SelectAnswer(List<string> choices)
        {
            Console.Write($"Enter the number of the correct choice ({MIN_CHOICE}-{ANSWER_OPTIONS}): "); // Prompt the user to select the correct answer
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
    }
}