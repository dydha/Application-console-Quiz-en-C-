using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizApp
{
    public class QuizRepository
    {
        private const string _filePath = "Quiz.json";  // Fichier remplaçant la base de données.
        private static List<Quiz> _quiz = new(); // Liste des taches pour manipuler les données.

        public static void AddQuiz(Quiz quiz)
        {
            LoadTasksFromJsonFile();
            _quiz.Add(quiz);
            SaveTaskToJsonFile();

        }
        public static List<Quiz> GetQuizzes()
        {
            LoadTasksFromJsonFile();
            var quizzes = _quiz.ToList();
            return quizzes.Count > 0 && quizzes != null ? quizzes : new List<Quiz>();
        }
        //Méthode pour sauvegarder la liste des taches dans le fichier.
        private static void SaveTaskToJsonFile()
        {
            // Sérialisation de la liste.
            string jsonData = JsonSerializer.Serialize(_quiz, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData); //Enregistrement de la liste dans le fichier
        }

        // Méthode pour récupérer les taches à partir du fichier JSON.
        private static void LoadTasksFromJsonFile()
        {
            if (File.Exists(_filePath)) //Vérification si le fichier existe. Si non, un fichier est créé.
            {
                string jsonData = File.ReadAllText(_filePath); //Lecture des données du fichier.
                if (!string.IsNullOrEmpty(jsonData)) //Si le fichier n'est pas vide, les données sont affectées à la liste des taches.
                    _quiz = JsonSerializer.Deserialize<List<Quiz>>(jsonData);

            }

        }
    }
}
