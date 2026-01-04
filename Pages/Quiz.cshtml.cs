using Microsoft.AspNetCore.Mvc.RazorPages;

namespace QuizWebApp.Pages
{
    public class QuizModel : PageModel
    {
        public int QuizId { get; set; }

        public void OnGet(int id)
        {
            QuizId = id;
        }
    }
}