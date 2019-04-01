using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DocumentService.Data;
using DocumentService.Models;

namespace DocumentService.Pages.MemberServices
{
    public class EditModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public EditModel(DocumentService.Data.ApplicationDbContext context)
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
           ViewData["HandyMemberID"] = new SelectList(_context.HandyMember, "ID", "ID");
           ViewData["JobTypeID"] = new SelectList(_context.JobType, "ID", "ID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MemberService).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberServiceExists(MemberService.MemberServiceID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MemberServiceExists(int id)
        {
            return _context.MemberService.Any(e => e.MemberServiceID == id);
        }
    }
}
