using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuizMaker
{
    internal class Logic
    {
        public static void SaveQuestions(List<Questions> questions)          // Serializes a list of questions and saves it to an XML file.
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Questions>));      // Create an XmlSerializer that can handle a list of 'Questions' objects

            using (FileStream file = new FileStream(Constants.QUIZ_QUESTIONS, FileMode.Create))     // Create or overwrite the XML file at the specified path
            {
                serializer.Serialize(file, questions);       // Serialize the questions list and write it to the file
            }
        }

        public static List<Questions> LoadQuestions()     // Deserializes the XML file and returns a list of questions
        {
            if (!File.Exists(Constants.QUIZ_QUESTIONS))        // If the XML file does not exist, return an empty list of questions
                return new List<Questions>();

            XmlSerializer serializer = new XmlSerializer(typeof(List<Questions>));           // Create an XmlSerializer that can deserialize a list of 'Questions' objects
            using (FileStream file = new FileStream(Constants.QUIZ_QUESTIONS, FileMode.Open))       // Open the file for reading
            {
                return (List<Questions>)serializer.Deserialize(file);    // Deserialize the XML content back into a List<Questions> and return it
            }
        }

        public static int TakeQuiz(List<Questions> questions)
        {
            int score = 0;
            Random random = new Random();

            var pickAQuestions = questions.OrderBy(q => random.Next()).ToList();

            foreach (var question in pickAQuestions)
            {
                UI.DisplayQuestion(question);
                int userAnswer = UI.GetUserAnswer(question.Choices.Count);

                if (userAnswer == question.correctAnswer)
                {
                    score++;
                    UI.DisplayCorrectAnswerFeedback();
                }
                else
                {
                    UI.DisplayIncorrectAnswerFeedback(question.Choices[question.correctAnswer]);
                }
            }

            return score;
        }
    }
}