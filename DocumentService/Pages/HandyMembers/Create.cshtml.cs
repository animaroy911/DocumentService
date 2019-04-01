using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocumentService.Data;
using DocumentService.Models;

namespace DocumentService.Pages.HandyMembers
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
        public HandyMember HandyMember { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var emptyHandyMember = new HandyMember();

            if(await TryUpdateModelAsync<HandyMember>(
                emptyHandyMember,
                "HandyMember", //Prefix for form value
                s => s.FirstName, s => s.LastName, s => s.DateOfBirth, s => s.Email))
            {
                _context.HandyMember.Add(HandyMember);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
            }

            return null;
        }
    }
}