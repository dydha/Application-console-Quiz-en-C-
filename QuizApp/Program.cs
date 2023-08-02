using System;

namespace QuizApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            while(true) 
            {
                Console.WriteLine("Commencer un quiz ? (o/n)");
                string? input = Console.ReadLine();
                if (!String.IsNullOrEmpty(input))
                {
                    input = input.ToLower();
                    if (input.ToLower() == "o")
                    {
                        string? playerName;
                        Console.WriteLine("Entrer votre pseudo :");
                        while (true)
                        {
                            playerName = Console.ReadLine();
                            if (!String.IsNullOrEmpty(playerName))
                            {
                                QuestionDifficulty difficulty = DisplayDifficultyMenu();
                                 QuizController.QuizStart(playerName,difficulty);
                                break;
                            }   
                        }
                        
                    }
                    else if (input.ToLower() == "n")
                        return;
                } 
            }
        }
        public static QuestionDifficulty DisplayDifficultyMenu()
        {
            Console.WriteLine("Choisissez la difficulté :");
            Console.WriteLine("1 - Facile");
            Console.WriteLine("2 - Moyen");
            Console.WriteLine("3 - Difficile");

            while (true)
            {
                string input = Console.ReadLine();
                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            return QuestionDifficulty.Facile;
                        case 2:
                            return QuestionDifficulty.Moyen;
                        case 3:
                            return QuestionDifficulty.Difficile;
                        default:
                            Console.WriteLine("Choix invalide. Veuillez choisir une option valide.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Choix invalide. Veuillez choisir une option valide.");
                }
            }
        }

    }
}
