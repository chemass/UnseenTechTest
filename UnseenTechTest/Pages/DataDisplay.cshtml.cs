using Microsoft.AspNetCore.Mvc.RazorPages;
using UnseenTechTest.Data;

namespace UnseenTechTest.Pages
{
    public class DataDisplayModel(AppDbContext context) : PageModel
    {
        private readonly AppDbContext _context = context;

        public string SearchTerm { get; set; } = string.Empty;
        public List<string> Words { get; set; } = [];

        public void OnGet(string searchTerm)
        {
            SearchTerm = searchTerm;
            Words = string.IsNullOrWhiteSpace(searchTerm)
                ? _context.Words.Select(w => w.Word).ToList()
                : _context.Words
                    .Where(w => w.Word.Contains(searchTerm))
                    .Select(w => w.Word)
                    .ToList();
        }
    }
}
