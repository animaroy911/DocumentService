using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentService.Models
{
    public class JobType
    {
        public int ID { get; set; }

        [Display(Name = "Job Name")]
        public string TaskName { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }

        public ICollection<MemberService> MemberServices { get; set; }
    }
}
