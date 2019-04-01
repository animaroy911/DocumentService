using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocumentService.Data;
using DocumentService.Models;

namespace DocumentService.Pages.MemberServices
{
    public class DeleteModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public DeleteModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MemberService MemberService { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MemberService = await _context.MemberService
                .Include(m => m.HandyMember)
                .Include(m => m.JobType).FirstOrDefaultAsync(m => m.MemberServiceID == id);

            if (MemberService == null)
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

            MemberService = await _context.MemberService.FindAsync(id);

            if (MemberService != null)
            {
                _context.MemberService.Remove(MemberService);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
