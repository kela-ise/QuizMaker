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

        private static readonly XmlSerializer serializer = new XmlSerializer(typeof(List<Questions>)); // XmlSerializer instance for serializing/deserializing quiz questions

        public static void SaveQuestions(List<Questions> questions)          // Serializes a list of questions and saves it to an XML file.
        {
            using (FileStream file = new FileStream(Constants.QUIZ_QUESTIONS, FileMode.Create))     // Create or overwrite the XML file at the specified path
            {
                serializer.Serialize(file, questions);       // Serialize the questions list using the shared serializer
            }
        }

        public static List<Questions> LoadQuestions()     // Deserializes the XML file and returns a list of questions
        {
            if (!File.Exists(Constants.QUIZ_QUESTIONS))        // If the XML file does not exist, return an empty list of questions
                return new List<Questions>();

            using (FileStream file = new FileStream(Constants.QUIZ_QUESTIONS, FileMode.Open))       // Open the file for reading
            {
                return (List<Questions>)serializer.Deserialize(file);    // Deserialize using the shared serializer
            }
        }
    }
}