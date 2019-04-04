using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentService.Models
{
    public class IntBoolDTO
    {
        [NotMapped]
        public int Id { get; set; }
        [NotMapped]
        public bool Checked { get; set; }
    }
}
