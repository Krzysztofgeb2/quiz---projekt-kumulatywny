using System.Collections.ObjectModel;
using avaloniaQuiz.Entity;
using avaloniaQuiz.Repository;

namespace avaloniaQuiz.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ObservableCollection<QuizEntity> Quizzes { get; } = new();

    private QuizEntity? _selectedQuiz;
    public QuizEntity? SelectedQuiz
    {
        get => _selectedQuiz;
        set => SetProperty(ref _selectedQuiz, value);
    }

    public MainWindowViewModel(IQuizRepository repo)
    {
        foreach (var quiz in repo.GetAll())
            Quizzes.Add(quiz);
    }
}