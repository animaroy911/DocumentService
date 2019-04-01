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

namespace DocumentService.Pages.HandyMembers
{
    public class EditModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public EditModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HandyMember HandyMember { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HandyMember = await _context.HandyMember.FindAsync(id);

            if (HandyMember == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int?id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var HandyMemberToUpdate = await _context.HandyMember.FindAsync(id);

            if(await TryUpdateModelAsync<HandyMember>(
                HandyMemberToUpdate,
                "HandyMember",
                s => s.FirstName, s => s.LastName, s => s.DateOfBirth, s => s.Email))

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HandyMemberExists(HandyMember.ID))
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

        private bool HandyMemberExists(int id)
        {
            return _context.HandyMember.Any(e => e.ID == id);
        }
    }
}
