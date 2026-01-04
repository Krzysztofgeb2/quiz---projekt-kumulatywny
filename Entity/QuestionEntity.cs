namespace QuizWebApp;

public class QuestionEntity
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;

    public int QuizId { get; set; }
    public QuizEntity Quiz { get; set; } = null!;

    public ICollection<AnswerEntity> Answers { get; set; } = new List<AnswerEntity>();
}
