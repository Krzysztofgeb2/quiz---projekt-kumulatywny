namespace projectC.Abstractions
{
    public interface IAnswer
    {
        string Text { get; }
        bool IsCorrect { get; }
    }
}