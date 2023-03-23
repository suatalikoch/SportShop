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

        public Product()
        {
            
        }

        public Product(string name, string description, decimal price, double discount, string image, int categoryId, int subCategoryId)
        {
            Name = name;
            Description = description;
            Price = price;
            Discount = discount;
            Image = image;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Description} {Price} {Discount} {Image} {CategoryId} {SubCategoryId}";
        }
    }
}
