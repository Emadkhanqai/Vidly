using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Validation;

namespace Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        [Display(Name = "Date Of Birth")]
        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}