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

        public async Task OnGetAsync()
        {
            Book = await _context.Book.ToListAsync();
            foreach (Book book in Book)
            {
                book.BookSegments = new List<Segment>();
                book.SegmentIdsString = book.SegmentIdsString ?? "";
                foreach (string segmentIdString in book.SegmentIdsString.Split(","))
                {
                    int segmentId = 0;
                    if (int.TryParse(segmentIdString, out segmentId))
                    {
                        if (_context.Segment.Any(m => m.Id == segmentId))
                        {
                            book.BookSegments.Add(_context.Segment.First(m => m.Id == segmentId));
                        }
                        else
                        {
                            book.BookSegments.Add(new Segment { Header = "This segment has been deleted." });
                        }
                    }
                    else
                    {
                        book.BookSegments.Add(new Segment { Header = "This segment ID is invalid." });
                    }
                }
                if(book.BookSegments.Count > 5)
                {
                    book.BookSegments = book.BookSegments.Take(5).Append(new Segment { Header = "..." }).ToList();
                }
            }
        }
    }
}
