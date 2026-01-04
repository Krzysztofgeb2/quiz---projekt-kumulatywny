using System.Collections.Generic;
using projectC.Abstractions;

namespace projectC.Models
{
    public class Question : IQuestion
    {
        public string Content { get; }

        private readonly List<IAnswer> _answers = new List<IAnswer>();
        public IReadOnlyList<IAnswer> Answers => _answers.AsReadOnly();

        public Question(string content)
        {
            Content = content;
        }

        public void AddAnswer(IAnswer answer)
        {
            _answers.Add(answer);
        }

        public bool IsCorrectAnswer(int index)
        {
            return index >= 0 &&
                   index < _answers.Count &&
                   _answers[index].IsCorrect;
        }
    }
}