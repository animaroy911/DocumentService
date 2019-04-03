using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DocumentService.Data;
using DocumentService.Models;
using HtmlAgilityPack;
using System.IO;
using System.Web;
using System.Text.RegularExpressions;
using System.Text;

namespace DocumentService.Pages.Segments
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
        public Segment Segment { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Segment.Add(Segment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostSecondAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Segment.RemoveRange(_context.Segment);
            await _context.SaveChangesAsync();
            //return RedirectToPage("./Index");

            var filePath = Path.GetTempFileName();

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await Segment.UploadDocumentFile.CopyToAsync(fileStream);
            }

            HtmlDocument document = new HtmlDocument();
            using (MemoryStream memoryStream = new MemoryStream())
            {
                await Segment.UploadDocumentFile.CopyToAsync(memoryStream);
                document.Load(filePath);

                

                HtmlNode root = document.DocumentNode.SelectNodes("//div[@class='WordSection1']").FirstOrDefault();

                foreach (var eachNode in root.SelectNodes("//*"))
                    eachNode.Attributes.RemoveAll();

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
                        currentSegment.Owner = Globals.CURRENT_USER;
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
                    _context.Segment.Add(segment);
                    await _context.SaveChangesAsync();
                }

                //await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}