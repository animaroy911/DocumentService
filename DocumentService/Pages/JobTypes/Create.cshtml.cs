using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocumentService.Data;
using DocumentService.Models;

namespace DocumentService.Pages.JobTypes
{
    public class CreateModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public CreateModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public JobType JobType { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.JobType.Add(JobType);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}