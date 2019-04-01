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

            var filePath = @"C:\Users\anima\Desktop\TEMP\xx";

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
                string header = "";
                List<string> lines = new List<string>();
                foreach (HtmlNode node in root.ChildNodes)
                {
                    if (node.OuterHtml.TrimStart().StartsWith("<div"))
                    {
                        if (!string.IsNullOrWhiteSpace(header))
                        {
                            Segment segment = new Segment();
                            segment.Header = header;
                            segment.Content = string.Join("", lines);
                            _context.Segment.Add(segment);
                            header = "";
                            lines = new List<string>();
                        }
                        header = node.InnerText;
                    }
                    else if (node.OuterHtml.TrimStart().StartsWith("<p"))
                    {
                        lines.Add(node.InnerText);
                    }
                }

                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}