using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace QuizApp
{
    public class QuizController
    {
        private static Timer timer;

      private static bool isTimerElapsed = false; // Variable pour indiquer si le chrono a expiré
        private static Random rand = new Random();
        private static int TimeLimitInSeconds = 10; // Temps limite de 10 secondes pour chaque question
        public static void QuizStart(string playerName, QuestionDifficulty difficulty)
        {
            List<Question> questionList = GetRandomQuestions(difficulty);
            Quiz quiz = new() { PlayerName = playerName };
            int score = 0;

            for (int i = 0; i < questionList.Count; i++)
            {
                isTimerElapsed = false; // Réinitialise la variable avant chaque question
                // Crée le chronomètre pour chaque question
              timer = new Timer(OnTimerElapsed, null, TimeLimitInSeconds*1000, Timeout.Infinite);

                Console.WriteLine(questionList[i].Text);
                int counter = 1;
                foreach (string answer in questionList[i].Answers)
                {
                    Console.WriteLine($"{counter} - {answer}");
                    counter++;
                }
                Console.WriteLine("Choisir une réponse, Entrer l'index de la réponse choisie : ");
                while (!isTimerElapsed)
                {
                    string? input = Console.ReadLine();
                    
                    if (isTimerElapsed)
                    {
                        // Si le chrono a expiré et que l'utilisateur n'a pas répondu, passe à la question suivante
                        break;
                    }
                    else if (int.TryParse(input, out int index) && index >= 1 && index <= questionList[i].Answers.Count)
                    {
                        if (index == questionList[i].CorrectAnswerIndex + 1)
                            score++;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Veuillez entrer un index valide.");
                    }
                }
                // Arrête le chrono après chaque question
                timer.Dispose();
            }
            quiz.Score = score;
            QuizRepository.AddQuiz(quiz);
            double percentage = (score * 100) / questionList.Count;
            string value = string.Empty;
            if (percentage <= 25)
            {
                value = $"Entraine-toi encore {playerName}, ne lâche rien 😭";
            }
            else if (percentage < 50)
            {
                value = $"Bien joué {playerName}, continue à t'améliorer 😊 ";
            }
            else if (percentage < 99)
            {
                value = $"Excellent travail {playerName} ! Tu maîtrises le sujet 🔥";
            }
            else 
            {
                value = $"Félicitation {playerName} ! tu as fait {percentage}%";
            }
            Console.WriteLine($"Score : {score}/{questionList.Count}\t{value}");
            return;
        }

        public static List<Question> GetRandomQuestions(QuestionDifficulty difficulty)
        {
            List<Question> questionList = QuestionRepository.GetQuestions().Where(q => q.Difficulty == difficulty.ToString()).ToList() ;
            HashSet<Question> newQuestionList = new HashSet<Question>();
            int num;
            while (newQuestionList.Count < 5 && questionList.Count > 0)
            {
                num = rand.Next(questionList.Count);
                newQuestionList.Add(questionList[num]);
                questionList.RemoveAt(num);
            }
            return newQuestionList.ToList();
        }
        private static void OnTimerElapsed(object state)
        {
            Console.WriteLine("Temps écoulé ! Appuyer sur La touche Entrée du clavier pour continuer.");
            isTimerElapsed = true; // Indique que le chrono a expiré
        }

    }
}
