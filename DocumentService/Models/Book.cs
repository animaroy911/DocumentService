using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace DocumentService.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SegmentIdsString { get; set; }
        public string Owner { get; set; }

        [NotMapped]
        public List<Segment> BookSegments { get; set; }
        [NotMapped]
        public IFormFile UploadDocumentFile { get; set; }
    }
}
