namespace QuizWebApp;

public class QuizEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;

    public ICollection<QuestionEntity> Questions { get; set; } = new List<QuestionEntity>();
}
