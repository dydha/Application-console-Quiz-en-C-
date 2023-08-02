using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizApp
{
    public class Quiz
    {
        public string? PlayerName { get;set; }
        public int Score {get; set;}
        public QuestionDifficulty Difficulty { get; set;}
    }
}
