using projectC;

public static class seeder
{
    public static async Task SeedAsync(QuizDbContext context)
    {
        if (context.Quizzes.Any()) return;

        var quiz1 = new QuizEntity { Title = "Quiz OOP" };
        var quiz2 = new QuizEntity { Title = "Quiz C#" };

        quiz1.Questions.Add(new QuestionEntity
        {
            Content = "Co oznacza OOP?",
            Answers = new List<AnswerEntity>
            {
                new AnswerEntity { Text = "Object-Oriented Programming", IsCorrect = true },
                new AnswerEntity { Text = "Only One Programmer", IsCorrect = false }
            }
        });

        quiz2.Questions.Add(new QuestionEntity
        {
            Content = "Co to jest C#?",
            Answers = new List<AnswerEntity>
            {
                new AnswerEntity { Text = "Język programowania", IsCorrect = true },
                new AnswerEntity { Text = "System operacyjny", IsCorrect = false }
            }
        });

        await context.Quizzes.AddRangeAsync(quiz1, quiz2);
        await context.SaveChangesAsync();
    }
}