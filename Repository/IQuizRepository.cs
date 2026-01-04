namespace QuizWebApp;


public interface IQuizRepository
{
    void Add(QuizEntity quiz);
    QuizEntity? GetById(int id);
    IEnumerable<QuizEntity> GetAll();
    void Update(QuizEntity quiz);
    void Delete(int id);
}
