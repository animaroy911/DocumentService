using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DocumentService.Data;
using DocumentService.Models;

namespace DocumentService.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public EditModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public SelectList SegmentOptions { get; set; }

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public List<int> SelectedSegmentOptionIds { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SegmentOptions = new SelectList(_context.Segment, nameof(Segment.Id), nameof(Segment.Header));
            Book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Book.SegmentIdsString = string.Join(",", SelectedSegmentOptionIds);
            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookExists(int id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}
