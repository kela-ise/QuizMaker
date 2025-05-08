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
            List<Questions> questions = new List<Questions>();              // List to hold all questions entered by the user

            for (int i = 0; i < NUMBER_OF_QUESTIONS_TO_ENTER; i++) // Loop to prompt the user to enter multiple questions
            {
                Console.Write($"\nEnter question {i + DISPLAY_INDEX_OFFSET}: ");
                string userInput = Console.ReadLine(); // get question from the user

                List<string> choices = new List<string>();
                for (int j = 0; j < ANSWER_OPTIONS; j++)
                {
                    Console.Write($"Choice {j + DISPLAY_INDEX_OFFSET}: ");
                    string choice = Console.ReadLine(); // get answer choices for the current question
                    choices.Add(choice);
                }

                Console.WriteLine("\nPlease review the choices:");
                for (int j = 0; j < choices.Count; j++)
                {
                    Console.WriteLine($"{j + DISPLAY_INDEX_OFFSET}. {choices[j]}");
                }

                Console.Write($"Enter the number of the correct choice ({MIN_CHOICE}-{ANSWER_OPTIONS}): ");
                string correctInput = Console.ReadLine();  // Prompt the user to select the correct answer
                int correctIndex;
                while (!int.TryParse(correctInput, out correctIndex) ||
                       correctIndex < MIN_CHOICE || correctIndex > ANSWER_OPTIONS)
                {
                    Console.Write($"Please enter a valid number between {MIN_CHOICE} and {ANSWER_OPTIONS}: ");
                    correctInput = Console.ReadLine();
                }

                int zeroBasedCorrectIndex = correctIndex - DISPLAY_INDEX_OFFSET;   // Convert the user-friendly choice number to a zero-based index

                questions.Add(new Questions     // Create a new question object and add it to the list
                {
                    questionEntry = userInput,
                    Choices = choices,
                    correctAnswer = zeroBasedCorrectIndex
                });
            }
            Console.WriteLine($"\n{NUMBER_OF_QUESTIONS_TO_ENTER} questions created!");
            return questions; // Now returns the list instead of saving
        }
    }
}