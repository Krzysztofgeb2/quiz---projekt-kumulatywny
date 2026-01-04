namespace QuizWebApp;


using Microsoft.EntityFrameworkCore;

public class QuizDbContext : DbContext
{
    public DbSet<QuizEntity> Quizzes => Set<QuizEntity>();
    public DbSet<QuestionEntity> Questions => Set<QuestionEntity>();
    public DbSet<AnswerEntity> Answers => Set<AnswerEntity>();
    
    // Konstruktor wymagany przez AddDbContext
    public QuizDbContext(DbContextOptions<QuizDbContext> options)
        : base(options)
    {
    }

    // Parameterless constructor (opcjonalny, np. do konsoli/seed)
    public QuizDbContext()
    {
    }

    // Możesz zachować OnConfiguring, ale nie jest potrzebne jeśli używasz DI
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (!options.IsConfigured)
        {
            options.UseSqlite("Data Source=quiz.db");
        }
    }
}
