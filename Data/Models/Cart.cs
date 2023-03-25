using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [PrimaryKey(nameof(UserId), nameof(ProductId))]
    public class Cart
    {
        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }

        public Cart()
        { }

        public Cart(int userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
        }

        public override string ToString()
        {
            return $"{UserId} {ProductId}";
        }
    }
}
