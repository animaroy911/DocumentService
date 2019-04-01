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
    public class IndexModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public IndexModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Segment> Segment { get;set; }

        public async Task OnGetAsync()
        {
            Segment = await _context.Segment.ToListAsync();
        }
    }
}
