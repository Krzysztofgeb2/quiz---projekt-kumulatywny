using System.Collections.Generic;

namespace avaloniaQuiz.Entity;

public class QuestionEntity
{
    public int Id { get; set; }
    public string Content { get; set; } = "";
    public List<AnswerEntity> Answers { get; set; } = new();
}