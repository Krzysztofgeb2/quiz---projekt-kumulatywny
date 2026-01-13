using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Layout;
using avaloniaQuiz.Data;
using avaloniaQuiz.Repository;
using avaloniaQuiz.Entity;
using System.Linq;

namespace avaloniaQuiz;

public partial class MainWindow : Window
{
    private int totalScore = 0;
    private int totalQuestions = 0;

    public MainWindow()
    {
        InitializeComponent();

        var context = new QuizDbContext();
        var repo = new QuizRepository(context);
        var quizzes = repo.GetAll();

        foreach (var quiz in quizzes)
        {
            var quizTitle = new TextBlock
            {
                Text = quiz.Title,
                FontWeight = FontWeight.Bold,
                FontSize = 18,
                Margin = new Thickness(0, 10, 0, 5)
            };
            MainStackPanel.Children.Add(quizTitle);

            totalQuestions = quiz.Questions.Count;

            foreach (var question in quiz.Questions)
            {
                var questionPanel = new StackPanel
                {
                    Margin = new Thickness(10, 5, 0, 15)
                };

                var questionText = new TextBlock
                {
                    Text = question.Content,
                    FontWeight = FontWeight.SemiBold,
                    FontSize = 14,
                    Margin = new Thickness(0, 0, 0, 5)
                };
                questionPanel.Children.Add(questionText);

                foreach (var answer in question.Answers)
                {
                    var answerButton = new Button
                    {
                        Content = answer.Text,
                        Margin = new Thickness(10, 2, 0, 2),
                        Tag = answer.IsCorrect
                    };

                    answerButton.Click += (s, e) =>
                    {
                        // Tylko pierwsze kliknięcie liczy punkty
                        if (!answerButton.IsEnabled) return;

                        if ((bool)answerButton.Tag)
                        {
                            answerButton.Background = Brushes.LightGreen;
                            totalScore++;
                        }
                        else
                        {
                            answerButton.Background = Brushes.LightCoral;
                        }

                        // zablokuj wszystkie przyciski przy tym pytaniu
                        foreach (var child in questionPanel.Children.OfType<Button>())
                        {
                            child.IsEnabled = false;
                        }

                        // Jeśli to było ostatnie pytanie, pokaż wynik
                        if (MainStackPanel.Children.OfType<StackPanel>().Count() == totalQuestions)
                        {
                            ShowResult();
                        }
                    };

                    questionPanel.Children.Add(answerButton);
                }

                MainStackPanel.Children.Add(questionPanel);
            }
        }
    }

    private void ShowResult()
    {
        var resultText = new TextBlock
        {
            Text = $"Twój wynik: {totalScore}/{totalQuestions}",
            FontWeight = FontWeight.Bold,
            FontSize = 16,
            Margin = new Thickness(0, 10, 0, 10)
        };
        MainStackPanel.Children.Add(resultText);
    }
}
