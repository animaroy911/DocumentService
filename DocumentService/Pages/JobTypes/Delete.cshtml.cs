using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocumentService.Data;
using DocumentService.Models;

namespace DocumentService.Pages.JobTypes
{
    public class DeleteModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public DeleteModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public JobType JobType { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            JobType = await _context.JobType.FirstOrDefaultAsync(m => m.ID == id);

            if (JobType == null)
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

            JobType = await _context.JobType.FindAsync(id);

            if (JobType != null)
            {
                _context.JobType.Remove(JobType);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
