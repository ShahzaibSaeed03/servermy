using Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserSignupDTO
    {
        [Required]
        [StringLength(20, ErrorMessage = "length cant be more than 20 latters")]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(20, ErrorMessage = "length cant be more than 20 latters")]
        public string LastName { get; set; } = null!;

        [Required]
        public string Address1 { get; set; } = null!;
        public string? Address2 { get; set; }
        public string ZipCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public string? stateRegion { get; set; }
        public int IdCountry { get; set; }
        public string? PhoneNumber { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "length cant be more than 20 latters")]
        public string Profession { get; set; } = null!;

        [Required]
        [StringLength(20, ErrorMessage = "length cant be more than 20 latters")]
        public string HowHearAboutUs { get; set; } = null!;

        [EmailAddress]
        [Required]
        [StringLength(50, ErrorMessage = "length cant be more than 20 latters")]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        [StringLength(20, ErrorMessage = "length cant be more than 20 latters")]
        public string CompanyName { get; set; } = null!;

        [StringLength(40, ErrorMessage = "length cant be more than 40 latters")]
        public string? OwnerName { get; set; }

        [StringLength(20, ErrorMessage = "length cant be more than 20 latters")]
        public string? CompanyOfficialId { get; set; } = null!;

        [Required]
        public string BillingAddress1 { get; set; } = null!;
        public string? BillingAddress2 { get; set; }
        public string BillingZipCode { get; set; } = null!;
        public string BillingCity { get; set; } = null!;
        public string? BillingstateRegion { get; set; }
        public int IdBillingCountry { get; set; }
        public string? BillingPhoneNumber { get; set; }
    }
}
