namespace QuizWebApp;


public static class seeder
{ 
    public static void Seed(QuizDbContext context) 
    {
            // Sprawdzenie, czy baza już zawiera quizy
            if (context.Quizzes.Any())
            {
                Console.WriteLine("Baza już zawiera quizy. Seed pominięty.");
                return;
            }

            // 🔹 Quiz 1
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

            // 🔹 Quiz 2
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

            // Dodanie do bazy
            context.Quizzes.AddRange(quiz1, quiz2);
            context.SaveChanges();

            Console.WriteLine("Seedowanie zakończone – dodano 2 quizy po 2 pytania.");
    }
}

