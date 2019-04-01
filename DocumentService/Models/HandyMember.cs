using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocumentService.Models
{
    public class HandyMember
    {
        public int ID { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [DataType(DataType.EmailAddress), Required]
        public string Email { get; set; }

        
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Display(Name = "Apt #")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        [StringLength(10)]
        public string AptNum { get; set; }

        [RegularExpression(@"^[0-9]+[a-zA-Z""'\s-]*$"), StringLength(100)]
        public string Street { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$"), StringLength(100)]
        public string City { get; set; }

        [RegularExpression(@"^([ABCEGHJKLMNPRSTVXYabceghjklmnprstvxy]\d[ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvxy])\ {0,1}(\d[ABCEGHJKLMNPRSTVWXYZabceghjklmnprstvxy]\d)$"), StringLength(10)]
        public string ZIP { get; set; }

        public string Photo { get; set; }
        public bool Tasker { get; set; }

        public ICollection<MemberService> MemberServices { get; set; }
    }
}
