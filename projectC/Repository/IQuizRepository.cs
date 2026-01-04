namespace projectC;


public interface IQuizRepository
{
    Task<QuizEntity?> GetByIdAsync(int id);
}

