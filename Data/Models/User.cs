using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
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
        [MaxLength(255)]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        [MinLength(3), MaxLength(255)]
        public string Password { get; set; }

        [Phone]
        [MaxLength(255)]
        public string? Phone { get; set; }
        [MaxLength(255)]
        public string? Address { get; set; }
        [MaxLength(255)]
        public string? City { get; set; }
        [MaxLength(255)]
        public string? Region { get; set; }
        [MaxLength(255)]
        public string? PostalCode { get; set; }
        [MaxLength(255)]
        public string? Country { get; set; }
        public Role? Role { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public bool IsActive { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset RegistrationDate { get; set; }
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTimeOffset LastLoginDate { get; set; }
        public object? Name { get; set; }

        public User()
        { }

        public User(string firstName, string lastName, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
        }

        public User(string firstName, string lastName, string email, string password, string? phone, string? address, string? city, string? region, string? postalCode, string? country, Role? role, bool isEmailConfirmed, bool isActive, DateTimeOffset registrationDate, DateTimeOffset lastLoginDate)
            : this(firstName, lastName, email, password)
        {
            Phone = phone;
            Address = address;
            City = city;
            Region = region;
            PostalCode = postalCode;
            Country = country;
            Role = role;
            IsEmailConfirmed = isEmailConfirmed;
            IsActive = isActive;
            RegistrationDate = registrationDate;
            LastLoginDate = lastLoginDate;
        }

        public override string ToString()
        {
            return $"{Id} {FirstName} {LastName} {Email} {Phone} {Address} {City} {Region} {PostalCode} {Country} {Role} {IsEmailConfirmed} {IsActive} {RegistrationDate} {LastLoginDate}";
        }
    }
}
