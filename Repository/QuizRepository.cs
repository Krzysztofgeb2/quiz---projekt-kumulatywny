namespace QuizWebApp;

using Microsoft.EntityFrameworkCore;

public class QuizRepository : IQuizRepository
{
    private readonly QuizDbContext _context;

    public QuizRepository(QuizDbContext context)
    {
        _context = context;
    }

    public void Add(QuizEntity quiz)
    {
        _context.Quizzes.Add(quiz);
        _context.SaveChanges();
    }

    public QuizEntity? GetById(int id)
    {
        return _context.Quizzes
            .Include(q => q.Questions)
            .ThenInclude(q => q.Answers)
            .FirstOrDefault(q => q.Id == id);
    }

    public IEnumerable<QuizEntity> GetAll()
    {
        return _context.Quizzes.ToList();
    }

    public void Update(QuizEntity quiz)
    {
        _context.Quizzes.Update(quiz);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var quiz = _context.Quizzes.Find(id);
        if (quiz == null) return;

        _context.Quizzes.Remove(quiz);
        _context.SaveChanges();
    }
}
