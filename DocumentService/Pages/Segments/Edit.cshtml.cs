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

namespace DocumentService.Pages.Segments
{
    public class EditModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public EditModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Segment Segment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, int? bookId)
        {
            if (id == null)
            {
                return NotFound();
            }
            Segment = await _context.Segment.FirstOrDefaultAsync(m => m.Id == id);
            if (Segment == null)
            {
                return NotFound();
            }
            Globals.FROM_BOOK_ID = bookId;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Segment.Owner = Globals.CURRENT_USER;
            _context.Attach(Segment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SegmentExists(Segment.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            if(Globals.FROM_BOOK_ID == null)
            {
                return RedirectToPage("./Index");
            }
            else
            {
                return Redirect("../Books/Details?id=" + Globals.FROM_BOOK_ID);
            }
        }

        private bool SegmentExists(int id)
        {
            return _context.Segment.Any(e => e.Id == id);
        }
    }
}
