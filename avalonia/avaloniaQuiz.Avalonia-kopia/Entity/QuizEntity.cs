using System.Collections.Generic;

namespace avaloniaQuiz.Entity;

public class QuizEntity
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public List<QuestionEntity> Questions { get; set; } = new();
}