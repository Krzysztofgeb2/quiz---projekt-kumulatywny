using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuizWebApp;

namespace QuizWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly QuizDbContext _context;
        public List<QuizEntity> Quizzes { get; set; } = new();

        public IndexModel(QuizDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Quizzes = _context.Quizzes.ToList();
        }
    }
}