using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentService.Models
{
    public class Segment
    {
        public int Id { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public string Owner { get; set; }

        [NotMapped]
        public IFormFile UploadDocumentFile { get; set; }
    }
}
