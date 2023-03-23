using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    [PrimaryKey(nameof(UserId), nameof(ProductId))]
    public class Cart
    {
        [ForeignKey(nameof(UserId))]
        public int UserId { get; set; }

        [ForeignKey(nameof(ProductId))]
        public int ProductId { get; set; }

        public override string ToString()
        {
            return $"{UserId} {ProductId}";
        }
    }
}
