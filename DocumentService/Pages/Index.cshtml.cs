using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DocumentService.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostCrothall()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Globals.CURRENT_USER = "Crothall";
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostHospitalA()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Globals.CURRENT_USER = "Hospital A";
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostHospitalB()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Globals.CURRENT_USER = "Hospital B";
            return RedirectToPage("./Index");
        }

        public IActionResult OnPostHospitalC()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Globals.CURRENT_USER = "Hospital C";
            return RedirectToPage("./Index");
        }
    }
}
