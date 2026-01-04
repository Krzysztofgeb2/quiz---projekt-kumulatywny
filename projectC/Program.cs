using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using projectC;

namespace projectC
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await using var context = new QuizDbContext();
            
            await context.Database.MigrateAsync();
            
            await seeder.SeedAsync(context);

            Console.WriteLine("Projekt gotowy. Baza danych zawiera quizy.\n");
            
            var allQuizzes = await context.Quizzes.ToListAsync();
            if (!allQuizzes.Any())
            {
                Console.WriteLine("Brak quizów w bazie!");
                return;
            }

            Console.WriteLine("Dostępne quizy:");
            for (int i = 0; i < allQuizzes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {allQuizzes[i].Title}");
            }

            int quizChoice = ReadInt("Wybierz quiz: ", 1, allQuizzes.Count) - 1;
            
            var quiz = await context.Quizzes
                .Include(q => q.Questions)
                    .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == allQuizzes[quizChoice].Id);

            if (quiz == null)
            {
                Console.WriteLine("Wybrany quiz nie istnieje!");
                return;
            }

            Console.WriteLine($"\n== {quiz.Title} ==");

            int score = 0;
            
            foreach (var question in quiz.Questions)
            {
                Console.WriteLine();
                Console.WriteLine(question.Content);

                int i = 1;
                foreach (var answer in question.Answers)
                {
                    Console.WriteLine($"{i}. {answer.Text}");
                    i++;
                }

                int choice = ReadInt("Wybierz odpowiedź: ", 1, question.Answers.Count);
                
                var selectedAnswer = question.Answers.ElementAt(choice - 1);

                if (selectedAnswer.IsCorrect)
                {
                    Console.WriteLine("✔ Poprawna odpowiedź!");
                    score++;
                }
                else
                {
                    Console.WriteLine("✖ Błędna odpowiedź.");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Twój wynik: {score}/{quiz.Questions.Count}");
            Console.WriteLine("Koniec quizu!");
        }
        
        private static int ReadInt(string message, int min, int max)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value) && value >= min && value <= max)
                {
                    return value;
                }
                Console.WriteLine("Niepoprawny wybór. Spróbuj ponownie.");
            }
        }
    }
}
