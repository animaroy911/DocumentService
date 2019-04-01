using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocumentService.Data;
using DocumentService.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DocumentService.Pages.JobTypes
{
    public class IndexModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public IndexModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<JobType> JobType { get;set; }
        public SelectList Categories { get; set; }
        [BindProperty(SupportsGet = true)]
        public string FilterCategory { get; set; }

        public async Task OnGetAsync()
        {
            JobType = await _context.JobType.ToListAsync();
            IQueryable<string> queryCategory = from j in _context.JobType orderby j.Category select j.Category;
            var jobTypes = from j in _context.JobType select j;
            if (!string.IsNullOrEmpty(FilterCategory))
            {
                jobTypes = jobTypes.Where(x => x.Category == FilterCategory);
            }
            Categories = new SelectList(await queryCategory.Distinct().ToListAsync());
            JobType = await jobTypes.ToListAsync();
        }
    }
}
