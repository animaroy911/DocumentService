using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocumentService.Data;
using DocumentService.Models;

namespace DocumentService.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public CreateModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList SegmentOptions { get; set; }

        public IActionResult OnGet()
        {
            SegmentOptions = new SelectList(_context.Segment, nameof(Segment.Id), nameof(Segment.Header));
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public List<int> SelectedSegmentOptionIds { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Book.SegmentIdsString = string.Join(",", SelectedSegmentOptionIds);
            Book.Owner = Globals.CURRENT_USER;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}