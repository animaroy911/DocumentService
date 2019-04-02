using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocumentService.Data;
using DocumentService.Models;

namespace DocumentService.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public DetailsModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Book Book { get; set; }
        public List<Segment> BookSegments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book.FirstOrDefaultAsync(m => m.Id == id);
            BookSegments = Book.SegmentIdsString.Split(",").Select(segmentId => _context.Segment.FirstOrDefault(m => m.Id == int.Parse(segmentId))).ToList();

            if (Book == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
