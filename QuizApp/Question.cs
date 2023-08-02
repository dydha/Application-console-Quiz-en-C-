using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    public class Question
    {
        public string? Text { get; set; }
        public List<string> Answers { get; set; } = new();
        public string? Difficulty { get; set; }  
        public int CorrectAnswerIndex { get; set; }
    }
}
