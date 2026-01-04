using System.Collections.Generic;
using projectC.Abstractions;

namespace projectC.Models
{
    public class Quiz : IQuiz
    {
        public string Title { get; }

        private readonly List<IQuestion> _questions = new List<IQuestion>();
        public IReadOnlyList<IQuestion> Questions => _questions.AsReadOnly();

        public Quiz(string title)
        {
            Title = title;
        }

        public void AddQuestion(IQuestion question)
        {
            _questions.Add(question);
        }
    }
}


