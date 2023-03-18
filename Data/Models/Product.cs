using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public double Discount { get; set; }
        public string Image { get; set; }

        [ForeignKey(nameof(Category))]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(Subcategory))]
        public int SubCategoryId { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Description} {Price} {Discount} {Image} {CategoryId} {SubCategoryId}";
        }
    }
}
