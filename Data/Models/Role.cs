using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string? Description { get; set; }

        public Role()
        { }

        public Role(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Description}";
        }
    }
}
