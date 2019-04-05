using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocumentService.Data;
using DocumentService.Models;
using System.IO;
using HtmlAgilityPack;
using System.Web;

namespace DocumentService.Pages.Books
{
    public class CreateByUploadModel : PageModel
    {
        private readonly DocumentService.Data.ApplicationDbContext _context;

        public CreateByUploadModel(DocumentService.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var filePath = Path.GetTempFileName();

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await Book.UploadDocumentFile.CopyToAsync(fileStream);
            }

            HtmlDocument document = new HtmlDocument();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await Book.UploadDocumentFile.CopyToAsync(memoryStream);
                document.Load(filePath);



                HtmlNode root = document.DocumentNode.SelectNodes("//div[@class='WordSection1']").FirstOrDefault();

                foreach (var eachNode in root.SelectNodes("//*"))
                {
                    eachNode.Attributes.RemoveAll();
                }

                List<Segment> segments = new List<Segment>();
                Segment currentSegment = null;
                foreach (HtmlNode node in root.ChildNodes)
                {
                    if (node.Name == "div")
                    {
                        if (currentSegment != null)
                        {
                            segments.Add(currentSegment);
                        }
                        currentSegment = new Segment();
                    }
                    if (node.Name == "div")
                    {
                        if (currentSegment != null && !string.IsNullOrWhiteSpace(HttpUtility.HtmlDecode(node.InnerText)))
                        {
                            currentSegment.Header = HttpUtility.HtmlDecode(node.InnerText);
                        }
                    }
                    else if (node.Name == "p")
                    {
                        if (currentSegment != null && !string.IsNullOrWhiteSpace(HttpUtility.HtmlDecode(node.InnerText)))
                        {
                            currentSegment.Content += HttpUtility.HtmlDecode(node.OuterHtml);
                        }
                    }
                }

                foreach (Segment segment in segments)
                {
                    segment.Owner = Globals.CURRENT_USER;
                    _context.Segment.Add(segment);
                    await _context.SaveChangesAsync();
                }

                Book.SegmentIdsString = string.Join(",", segments.Select(item=>item.Id));
                Book.Owner = Globals.CURRENT_USER;
                _context.Book.Add(Book);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}