using System.Collections.Generic;

namespace projectC.Abstractions
{
    public interface IQuiz
    {
        string Title { get; }
        IReadOnlyList<IQuestion> Questions { get; }

        void AddQuestion(IQuestion question);
    }
}