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
    public class IndexModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public IndexModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; }
        public List<Segment> BookSegments { get; set; }

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
            foreach (Book book in Book)
            {
                book.BookSegments = book.SegmentIdsString.Split(",").Where(item=>!string.IsNullOrWhiteSpace(item)).Select(segmentId => _context.Segment.FirstOrDefault(m => m.Id == int.Parse(segmentId))).ToList();
                if(book.BookSegments.Count > 5)
                {
                    book.BookSegments = book.BookSegments.Take(5).Append(new Segment { Header = "..." }).ToList();
                }
            }
        }
    }
}
