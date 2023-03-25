using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1), MaxLength(255)]
        public string Name { get; set; }

        [Required]
        [MinLength(50), MaxLength(1000)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public double? Discount { get; set; }

        [Required]
        [Url]
        public string Image { get; set; }

        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }

        [ForeignKey(nameof(Subcategory))]
        public int? SubCategoryId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Subcategory? Subcategory { get; set; }

        public Product()
        { }

        public Product(string name, string description, decimal price, double? discount, string image)
        {
            Name = name;
            Description = description;
            Price = price;
            Discount = discount;
            Image = image;
        }

        public Product(string name, string description, decimal price, double? discount, string image, int? categoryId, int? subCategoryId)
            : this(name, description, price, discount, image)
        {

            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Description} {Price} {Discount} {Image} {CategoryId} {SubCategoryId}";
        }
    }
}
