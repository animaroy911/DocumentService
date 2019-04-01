using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentService.Models
{
    public class MemberService
    {
        public int MemberServiceID { get; set; }
        public int HandyMemberID { get; set; }
        public int JobTypeID { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Rate { get; set; }
        public int Experience { get; set; }
        public bool Certificate { get; set; }

        public HandyMember HandyMember { get; set; }
        public JobType JobType { get; set; }
    }
}
