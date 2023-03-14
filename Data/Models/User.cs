using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SportShop.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(50)]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [MinLength(3), MaxLength(255)]
        public string Password { get; set; }

        [Phone]
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public bool IsEmailConfirmed { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime RegistrationDate { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastLoginDate { get; set; }

        [ForeignKey(nameof(Cart))]
        public int CartId { get; set; }
    }
}
