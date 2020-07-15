using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Membership Type")]
        public byte? MembershipTypeId { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        public string Title => Id != 0 ? "Edit Customer" : "New Customer";

        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            MembershipTypeId = customer.MembershipTypeId;
            BirthDate = customer.BirthDate;
            IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
        }
    }
}