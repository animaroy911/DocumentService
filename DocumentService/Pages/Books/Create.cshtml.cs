using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocumentService.Data;
using DocumentService.Models;
using System.IO;
using HtmlAgilityPack;
using System.Web;

namespace DocumentService.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public CreateModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public List<Segment> SegmentOptions { get; set; }

        public IActionResult OnGet()
        {
            SegmentOptions = _context.Segment.ToList();
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Book.SegmentIdsString = string.Join(",", SegmentOptions.Where(item=>item.Checked).Select(item=>item.Id));
            Book.Owner = Globals.CURRENT_USER;
            _context.Book.Add(Book);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}