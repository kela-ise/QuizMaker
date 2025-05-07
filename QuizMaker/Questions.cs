using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace QuizMaker
{
    [Serializable]
    public class Questions
    {

        public string questionEntry { get; set; }  // get the question that will be entered by the user
        public List<string> Choices { get; set; } // add a list of answer options/choices for the question
        public int correctAnswer { get; set; } // declare the correct answer for the question

        /**
        public Questions()
        {
            Choices = new List<string>();
        }
        **/
    }
        
}
