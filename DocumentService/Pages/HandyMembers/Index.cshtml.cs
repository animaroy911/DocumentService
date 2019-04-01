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
    public class IndexModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public IndexModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string CitySort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<HandyMember> HandyMember { get;set; }

        public async Task OnGetAsync(string sortOrder, 
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            CitySort = sortOrder == "City" ? "city_desc" : "City";
            if(searchString !=null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<HandyMember> HandyMemberIQ = from s in _context.HandyMember select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                HandyMemberIQ = HandyMemberIQ.Where(s => s.LastName.Contains(searchString)
                            || s.FirstName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    HandyMemberIQ = HandyMemberIQ.OrderByDescending(s => s.LastName);
                    break;
                case "City":
                    HandyMemberIQ = HandyMemberIQ.OrderBy(s => s.City);
                    break;
                default:
                    HandyMemberIQ = HandyMemberIQ.OrderBy(s => s.LastName);
                    break;
            }

            int pageSize = 3;
            HandyMember = await PaginatedList<HandyMember>.CreateAsync(
                HandyMemberIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
