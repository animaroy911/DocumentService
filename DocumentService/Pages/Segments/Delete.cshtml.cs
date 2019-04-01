using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocumentService.Data;
using DocumentService.Models;

namespace DocumentService.Pages.Segments
{
    public class DeleteModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public DeleteModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Segment Segment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Segment = await _context.Segment.FindAsync(id);

            if (Segment != null)
            {
                _context.Segment.Remove(Segment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
