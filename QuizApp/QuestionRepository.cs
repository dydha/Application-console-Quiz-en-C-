using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace QuizApp
{
    public class QuestionRepository
    {
        private const string _filePath  = "Questions.json";  // Fichier remplaçant la base de données.
        private static List<Question> _questions = new(); // Liste des taches pour manipuler les données.

        public static List<Question> GetQuestions()
        {
            LoadTasksFromJsonFile();
            var questions = _questions.ToList();
            return questions.Count > 0 && questions != null ? questions : new List<Question>(); 
        }
        //Méthode pour sauvegarder la liste des taches dans le fichier.
        private static void SaveTaskToJsonFile()
        {
            // Sérialisation de la liste.
            string jsonData = JsonSerializer.Serialize(_questions, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, jsonData); //Enregistrement de la liste dans le fichier
        }

        // Méthode pour récupérer les taches à partir du fichier JSON.
        private static void LoadTasksFromJsonFile()
        {
            if (File.Exists(_filePath)) //Vérification si le fichier existe. Si non, un fichier est créé.
            {
                string jsonData = File.ReadAllText(_filePath); //Lecture des données du fichier.
                if (!string.IsNullOrEmpty(jsonData)) //Si le fichier n'est pas vide, les données sont affectées à la liste des taches.
                    _questions = JsonSerializer.Deserialize<List<Question>>(jsonData);

            }

        }
    }
}
