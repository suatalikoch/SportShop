using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Subcategory
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        public Subcategory()
        { }

        public Subcategory(string name, int categoryId)
        {
            Name = name;
            CategoryId = categoryId;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {CategoryId}";
        }
    }
}
