using System;
using projectC.Abstractions;
using projectC.Models;

namespace projectC
{
    class Program
    {
        static void Main(string[] args)
        {
            IQuiz quiz = BuildQuiz();

            Console.WriteLine($"== {quiz.Title} ==");

            int score = 0;

            foreach (var question in quiz.Questions)
            {
                Console.WriteLine();
                Console.WriteLine(question.Content);

                for (int i = 0; i < question.Answers.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {question.Answers[i].Text}");
                }

                int choice = ReadInt("Wybierz odpowiedź: ", 1, question.Answers.Count) - 1;

                if (question.IsCorrectAnswer(choice))
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

        private static IQuiz BuildQuiz()
        {
            var quiz = new Quiz("Quiz OOP");

            var q1 = new Question("Co oznacza skrót OOP?");
            q1.AddAnswer(new Answer("Object-Oriented Programming", true));
            q1.AddAnswer(new Answer("Only One Programmer", false));
            q1.AddAnswer(new Answer("Open Operation Protocol", false));

            var q2 = new Question("Co jest podstawą programowania obiektowego?");
            q2.AddAnswer(new Answer("Dziedziczenie", true));
            q2.AddAnswer(new Answer("Tagowanie HTML", false));
            q2.AddAnswer(new Answer("Formatowanie CSS", false));

            quiz.AddQuestion(q1);
            quiz.AddQuestion(q2);

            return quiz;
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
