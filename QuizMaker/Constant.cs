using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace QuizMaker
{
    public static class Constants
    {
        public const string QUIZ_QUESTIONS = @"C:\Users\ebike\OneDrive\Desktop\C# Projects\QuizMaker\QuizMaker\Questions.xml";

        // constants for menu modes
        public const string CREATE_QUIZ_MODE = "1";
        public const string TAKE_QUIZ_MODE = "2";
        public const string EXIT_MODE = "3";
    }
}