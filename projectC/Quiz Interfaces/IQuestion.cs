using System.Collections.Generic;

namespace projectC.Abstractions
{
    public interface IQuestion
    {
        string Content { get; }
        IReadOnlyList<IAnswer> Answers { get; }

        void AddAnswer(IAnswer answer);
        bool IsCorrectAnswer(int index);
    }
}