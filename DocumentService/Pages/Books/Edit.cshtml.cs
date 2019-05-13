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

        [BindProperty]
        public Book Book { get; set; }

        [BindProperty]
        public List<Segment> SegmentOptions { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);
            SegmentOptions = _context.Segment.ToList();
            List<string> segmentIdsList = Book.SegmentIdsString.Split(",").ToList();
            for (int i = 0; i <= SegmentOptions.Count - 1; i++)
            {
                int index = segmentIdsList.IndexOf(SegmentOptions[i].Id.ToString());
                if(index > -1)
                {
                    SegmentOptions[i].Order = index;
                    SegmentOptions[i].Checked = true;
                }
                else
                {
                    SegmentOptions[i].Order = segmentIdsList.Count + i;
                }
            }
            SegmentOptions = SegmentOptions.OrderBy(item => item.Order).ToList();
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
            Book.Owner = Globals.CURRENT_USER;
            Book.SegmentIdsString = string.Join(",", SegmentOptions.OrderBy(item => item.Order).Where(item => item.Checked).Select(item => item.Id));
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
