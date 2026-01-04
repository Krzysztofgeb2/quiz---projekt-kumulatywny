using projectC.Abstractions;

namespace projectC.Models
{
    public class Answer : IAnswer
    {
        public string Text { get; }
        public bool IsCorrect { get; }

        public Answer(string text, bool isCorrect)
        {
            Text = text;
            IsCorrect = isCorrect;
        }
    }
}