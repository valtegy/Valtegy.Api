using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Valtegy.Domain.Entities
{
    public class Users : IdentityUser<int>
    {
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string MiddleName { get; set; }

        [MaxLength(100)]
        [Required]
        public string LastName1 { get; set; }

        [MaxLength(100)]
        public string LastName2 { get; set; }

        [Required]
        public DateTime BirthdayDate { get; set; }

        [MaxLength(6)]
        public string ValidatePhoneNumberCode { get; set; }

        [MaxLength(6)]
        public string ValidateEmailCode { get; set; }

        [MaxLength(6)]
        public string ValidateNewPhoneNumberCode { get; set; }

        [MaxLength(6)]
        public string ValidateNewEmailCode { get; set; }

        [Required]
        public bool IsEnabled { get; set; }

        public DateTime InsertDate { get; set; }

        public DateTime LastUpdate { get; set; }

        public int ModifyUserId { get; set; }
    }
}
