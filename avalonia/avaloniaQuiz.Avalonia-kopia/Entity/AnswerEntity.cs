namespace avaloniaQuiz.Entity;

public class AnswerEntity
{
    public int Id { get; set; }
    public string Text { get; set; } = "";
    public bool IsCorrect { get; set; }
}