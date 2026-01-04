namespace projectC;

using Microsoft.EntityFrameworkCore;

public class QuizDbContext : DbContext
{
    public DbSet<QuizEntity> Quizzes => Set<QuizEntity>();
    public DbSet<QuestionEntity> Questions => Set<QuestionEntity>();
    public DbSet<AnswerEntity> Answers => Set<AnswerEntity>();

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite("Data Source=quiz.db");
    }
}
