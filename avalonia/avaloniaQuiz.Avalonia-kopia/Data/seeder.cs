using avaloniaQuiz.Entity;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace avaloniaQuiz.Data
{
    public static class Seeder
    {
        public static async Task SeedAsync(QuizDbContext context, ILogger? logger = null)
        {
            if (await context.Quizzes.AnyAsync())
            {
                logger?.LogInformation("[Seed] Baza danych już zawiera quizy.");
                return;
            }

            var quiz1 = new QuizEntity
            {
                Title = "Quiz OOP",
                Questions = new List<QuestionEntity>
                {
                    new QuestionEntity
                    {
                        Content = "Co oznacza OOP?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Object Oriented Programming", IsCorrect = true },
                            new AnswerEntity { Text = "Only One Program", IsCorrect = false },
                            new AnswerEntity { Text = "Operational Object Protocol", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Content = "Co to jest dziedziczenie?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Mechanizm tworzenia klas pochodnych", IsCorrect = true },
                            new AnswerEntity { Text = "Łączenie baz danych", IsCorrect = false },
                            new AnswerEntity { Text = "Tworzenie nowego typu danych", IsCorrect = false }
                        }
                    }
                }
            };

            var quiz2 = new QuizEntity
            {
                Title = "Quiz C#",
                Questions = new List<QuestionEntity>
                {
                    new QuestionEntity
                    {
                        Content = "Co to jest LINQ?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Language Integrated Query", IsCorrect = true },
                            new AnswerEntity { Text = "Logical Indexed Queue", IsCorrect = false },
                            new AnswerEntity { Text = "Linked Input Query", IsCorrect = false }
                        }
                    },
                    new QuestionEntity
                    {
                        Content = "Jaka jest główna funkcja 'using' w C#?",
                        Answers = new List<AnswerEntity>
                        {
                            new AnswerEntity { Text = "Automatyczne zwalnianie zasobów", IsCorrect = true },
                            new AnswerEntity { Text = "Tworzenie aliasu dla przestrzeni nazw", IsCorrect = false },
                            new AnswerEntity { Text = "Deklaracja zmiennych statycznych", IsCorrect = false }
                        }
                    }
                }
            };

            await context.Quizzes.AddRangeAsync(quiz1, quiz2);
            await context.SaveChangesAsync();

            logger?.LogInformation("[Seed] Dodano 2 quizy z pytaniami.");
        }
    }
}
