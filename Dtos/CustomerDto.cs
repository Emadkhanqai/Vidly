﻿using System;
using System.ComponentModel.DataAnnotations;
using Vidly.Validation;

namespace Vidly.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Required")]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeId { get; set; }

        [Min18YearsIfMember]
        public DateTime? BirthDate { get; set; }
    }
}