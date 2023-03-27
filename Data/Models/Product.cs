using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        private string _name;
        private string _description;

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

        public Product(string name, string description, decimal price, string image)
        {
            Name = name;
            Description = description;
            Price = price;
            Image = image;
        }

        public Product(string name, string description, decimal price, double? discount, string image, int? categoryId, int? subCategoryId)
            : this(name, description, price, image)
        {
            Discount = discount;
            CategoryId = categoryId;
            SubCategoryId = subCategoryId;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Description} {Price} {Discount} {Image} {CategoryId} {SubCategoryId}";
        }

        [Required]
        [MinLength(1), MaxLength(255)]
        public string Name
        {
            get => _name;
            set
            {
                if (value.Length < 1 || value.Length > 255)
                {
                    throw new ValidationException("Name must be between [1-255] symbols");
                }

                _name = value;
            }
        }

        [Required]
        [MinLength(50), MaxLength(1000)]
        public string Description
        {
            get => _description;
            set
            {
                if (value.Length < 50 || value.Length > 1000)
                {
                    throw new ValidationException("Description must be between [50-1000] symbols");
                }

                _description = value;
            }
        }
    }
}
