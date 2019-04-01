using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DocumentService.Data;
using DocumentService.Models;

namespace DocumentService.Pages.HandyMembers
{
    public class DeleteModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public DeleteModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HandyMember HandyMember { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HandyMember = await _context.HandyMember.FirstOrDefaultAsync(m => m.ID == id);

            if (HandyMember == null)
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

            HandyMember = await _context.HandyMember.FindAsync(id);

            if (HandyMember != null)
            {
                _context.HandyMember.Remove(HandyMember);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
