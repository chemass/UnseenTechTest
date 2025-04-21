using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using UnseenTechTest.Data;
using UnseenTechTest.Models;

namespace UnseenTechTest.Pages
{
    public class DataSubmissionModel(AppDbContext context) : PageModel
    {
        private readonly AppDbContext _context = context;

        [BindProperty]
        [Required]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "Sentences must be between 1 and 500 characters long.")]
        public string Sentence { get; set; } = string.Empty;

        public string Message { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (string.IsNullOrWhiteSpace(Sentence))
            {
                Message = "Please enter a valid sentence.";
                return Page();
            }

            var words = Sentence.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            var validWords = words.Where(IsValidWord).ToList();

            if (validWords.Count == 0)
            {
                Message = "No valid words found.";
                return Page();
            }

            var longestWord = validWords.OrderByDescending(w => w.Length).First();

            if (_context.Words.Any(w => w.Word == longestWord))
            {
                Message = "Word already exists in the database.";
                return Page();
            }

            _context.Words.Add(new WordEntry { Word = longestWord });
            _context.SaveChanges();

            Message = $"Word '{longestWord}' has been added to the database.";
            return Page();
        }

        private bool IsValidWord(string word)
        {
            if (word.Length < 8) return false;
            if (!word.Any(char.IsUpper) || !word.Any(char.IsLower) || !word.Any(char.IsDigit)) return false;
            if (word.GroupBy(c => c).Any(g => g.Count() > 1)) return false;

            return true;
        }
    }
}
