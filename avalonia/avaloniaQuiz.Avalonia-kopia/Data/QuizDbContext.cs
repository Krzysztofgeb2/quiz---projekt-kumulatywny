using Microsoft.EntityFrameworkCore;
using avaloniaQuiz.Entity;

namespace avaloniaQuiz.Data;

public class QuizDbContext : DbContext
{
    public DbSet<QuizEntity> Quizzes => Set<QuizEntity>();
    public DbSet<QuestionEntity> Questions => Set<QuestionEntity>();
    public DbSet<AnswerEntity> Answers => Set<AnswerEntity>();

    public QuizDbContext(DbContextOptions<QuizDbContext> options) : base(options) { }
    public QuizDbContext() { }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
            options.UseSqlite("Data Source=quiz.db");
    }
}