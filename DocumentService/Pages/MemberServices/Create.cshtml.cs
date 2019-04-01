using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocumentService.Data;
using DocumentService.Models;

namespace DocumentService.Pages.MemberServices
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
        ViewData["HandyMemberID"] = new SelectList(_context.HandyMember, "ID", "ID");
        ViewData["JobTypeID"] = new SelectList(_context.JobType, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public MemberService MemberService { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MemberService.Add(MemberService);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}